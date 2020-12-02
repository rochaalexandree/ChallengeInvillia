using System.ComponentModel.DataAnnotations;

namespace ChallengeInvillia.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsOnLoan { get; set; }
    }
}