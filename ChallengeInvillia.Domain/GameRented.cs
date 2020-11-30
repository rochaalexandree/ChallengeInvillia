using System;

namespace ChallengeInvillia.Domain
{
    public class GameRented
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public Friend Friend { get; }
        public Game Game { get; }
    }
}