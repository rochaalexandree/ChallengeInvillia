 using Microsoft.EntityFrameworkCore;
using ChallengeInvillia.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ChallengeInvillia.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Proxies;

namespace ChallengeInvillia.Repository
{
    public class ChallengeInvilliaContext : IdentityDbContext<User, Role, int, 
                                                IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ChallengeInvilliaContext(DbContextOptions<ChallengeInvilliaContext> options) : base (options){}

        public DbSet<Friend> Friends { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameRented> GameRenteds { get; set; }

        override protected void OnModelCreating (ModelBuilder builder) 
        {           
            base.OnModelCreating(builder); 
            builder.Entity<UserRole>(userRole => 
            {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();

                userRole.HasOne(ur => ur.User).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();
            });
        }
        
    }
}