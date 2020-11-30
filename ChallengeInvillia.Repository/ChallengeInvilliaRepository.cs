using System.Linq;
using System.Threading.Tasks;
using ChallengeInvillia.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChallengeInvillia.Repository
{
    public class ChallengeInvilliaRepository : IChallengeInvilliaRepository
    {
        public readonly ChallengeInvilliaContext _context;

        public ChallengeInvilliaRepository(ChallengeInvilliaContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //Friends        
        public async Task<Friend[]> GetAllFriendAsync()
        {
            IQueryable<Friend> query = _context.Friends.Include(c => c.Games);

            query = query.OrderBy(c => c.Name);

            return await query.ToArrayAsync();
        }
        public async Task<Friend> GetFriendAsyncById(int FriendId)
        {
            IQueryable<Friend> query = _context.Friends.Include(c => c.Games);

            query = query.OrderBy(c => c.Name).Where(c => c.Id == FriendId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Friend[]> GetFriendAsyncByName(string Name)
        {
            IQueryable<Friend> query = _context.Friends.Include(c => c.Games);

            query = query.OrderBy(c => c.Name).Where(c => c.Name.ToLower().Contains(Name.ToLower()));

            return await query.ToArrayAsync();
        }

        // Games
        public async Task<Game[]> GetAllGameAsync()
        {
            IQueryable<Game> query = _context.Games;

            query = query.OrderBy(c => c.Name);

            return await query.ToArrayAsync();
        }

        public async Task<Game[]> GetGameAsyncById(int GameId)
        {
            IQueryable<Game> query = _context.Games;

            query = query.OrderBy(c => c.Name).Where(g => g.Id == GameId);

            return await query.ToArrayAsync();
        }
        public async Task<Game[]> GetGameAsyncByName(string Name)
        {
            IQueryable<Game> query = _context.Games;

            query = query.OrderBy(c => c.Name).Where(c => c.Name.ToLower().Contains(Name.ToLower()));

            return await query.ToArrayAsync();
        }

        // GameRented
        public async Task<GameRented[]> GetAllGameRentedAsync()
        {
            IQueryable<GameRented> query = _context.GameRenteds.Include(g => g.Friend).Include(g => g.Game);

            query = query.OrderByDescending(c => c.RentalDate);

            return await query.ToArrayAsync();
        }
        public async Task<GameRented> GetGameRentedAsyncById(int GameRentedId)
        {
            IQueryable<GameRented> query = _context.GameRenteds.Include(g => g.Friend).Include(g => g.Game);

            query = query.OrderByDescending(c => c.RentalDate).Where(g => g.Id == GameRentedId);

            return await query.FirstOrDefaultAsync();
        }

    }
}