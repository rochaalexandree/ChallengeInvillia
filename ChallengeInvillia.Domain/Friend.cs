using System.Collections.Generic;

namespace ChallengeInvillia.Domain
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<Game> Games { get; set;}
    }
}