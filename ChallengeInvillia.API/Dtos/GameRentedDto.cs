namespace ChallengeInvillia.API.Dtos
{
    public class GameRentedDto
    {
        public int Id { get; set; }
        public string RentalDate { get; set; }
        public FriendDto Friend { get; }
        public GameDto Game { get; }
    }
}