using System.ComponentModel.DataAnnotations;

namespace ChallengeInvillia.Domain
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsOnLoan { get; set; }
    }
}