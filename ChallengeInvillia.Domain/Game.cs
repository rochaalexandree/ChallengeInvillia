using System.ComponentModel.DataAnnotations;

namespace ChallengeInvillia.Domain
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsOnLoan { get; set; }
        public Friend friend { get; set; }
    }
}