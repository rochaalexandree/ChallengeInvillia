using Microsoft.EntityFrameworkCore;
using ChallengeInvillia.Domain;

namespace ChallengeInvillia.Repository
{
    public class ChallengeInvilliaContext : IdentityDbContext 
    {
        public ChallengeInvilliaContext(DbContextOptions<ChallengeInvilliaContext> options) : base (options){}

        public DbSet<Friend> Friends { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameRented> GameRenteds { get; set; }

        override protected void OnModelCreating (ModelBuilder builder) 
{ 
            builder.Entity<Game>().HasKey(table => new { 
                table.Id, table.Name
        }); 
}
        
    }
}