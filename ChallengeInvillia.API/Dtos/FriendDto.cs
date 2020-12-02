using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChallengeInvillia.API.Dtos
{
    public class FriendDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public string Name { get; set; }
        public int Age { get; set; }
        [EmailAddress, Required (ErrorMessage="O campo {0} é obrigatório")]
        public string Email { get; set; }
        public List<GameDto> Games { get; }
    }
}