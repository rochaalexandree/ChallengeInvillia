using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using ChallengeInvillia.API;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Net.Http.Headers;
using ChallengeInvillia.API.Dtos;

namespace ChallengeInvillia.UnitTest
{
    public class UnitTestFriends
    {
        private HttpClient _client;
        public string token = "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJhbGV4YW5kcmUiLCJuYmYiOjE2MDcwMTIwNTgsImV4cCI6MTYwNzA5ODQ1OCwiaWF0IjoxNjA3MDEyMDU4fQ.y5-RcfYMxJSbcK3fNcDygmtQGz-2jKXknr2MS09syatsA2fscImDWjnCjKpha9_hnXyRQ4jyBiE2GrHY_0l3kQ";

        public UnitTestFriends()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact]
        public async Task FriendsGetAllTestAsync()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/friends");
            request.Headers.Add("Authorization", token);
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(4)]
        public async Task FriendsGetOneTestAsync(int? id = null)
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"api/friends/{id}");
            request.Headers.Add("Authorization", token);
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task FriendsPostOneTestAsync()
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"), $"api/friends/");
            
            request.Headers.Add("Authorization", token);
            request.Properties.Add("Name: 'João', Id: 1, Age: 21, Email: 'aa@aaa.com'", new FriendDto());
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
