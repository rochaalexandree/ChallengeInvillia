namespace ChallengeInvillia.Domain.Identity
{
    public class User : IdentityUser
    {
        [Column(tyoeName = "nvarchar(150)")]
        public string FullName { get; set; }
    }
}