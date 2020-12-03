using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChallengeInvillia.API.Dtos
{
    public class FriendDto
    {
        public int FriendId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<GameDto> Games { get; }
    }
}