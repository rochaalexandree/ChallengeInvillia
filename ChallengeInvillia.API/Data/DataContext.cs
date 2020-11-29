using Microsoft.EntityFrameworkCore;
using ChallengeInvillia.API.Model;

namespace ChallengeInvillia.API.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<Friend> Friends { get; set; }
        
    }
}