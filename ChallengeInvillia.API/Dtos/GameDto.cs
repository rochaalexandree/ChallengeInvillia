using System.ComponentModel.DataAnnotations;

namespace ChallengeInvillia.API.Dtos
{
    public class GameDto
    {
        public int GameId { get; set; }
        [Required (ErrorMessage="O campo {0} é obrigatório")]
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsOnLoan { get; set; }
        public FriendDto friend { get; set; }
    }
}