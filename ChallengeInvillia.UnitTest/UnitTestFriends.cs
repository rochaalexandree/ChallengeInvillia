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
        public string token = "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJhbGV4YW5kcmUiLCJuYmYiOjE2MDY4NjUzODEsImV4cCI6MTYwNjk1MTc4MSwiaWF0IjoxNjA2ODY1MzgxfQ.PKX_tTyHTTfmCg8wbV_ZFfocAsxtPYGk1Eb2fgeyzaiRW5hMMziefCw4fjNK7DgcuxIMtH7k9oZMXS8evPROsw";

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
        [InlineData(1)]
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
            var friend = new FriendDto();
            friend.Name = "João";
            friend.Id = 1;
            friend.Age = 21;
            friend.Email = "aa@aaa.com";

            var request = new HttpRequestMessage(new HttpMethod("POST"), $"api/friends/");
            
            request.Headers.Add("Authorization", token);
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
