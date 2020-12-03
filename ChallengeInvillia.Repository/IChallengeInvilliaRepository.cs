using System.Threading.Tasks;
using ChallengeInvillia.Domain;

namespace ChallengeInvillia.Repository
{
    public interface IChallengeInvilliaRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

         Task<Friend[]> GetAllFriendAsync();
         Task<Friend> GetFriendAsyncById(int FriendId);
         Task<Friend[]> GetFriendAsyncByName(string Name);
         Task<Game[]> GetAllGameAsync();
         Task<Game> GetGameAsyncById(int GameId);
         Task<Game[]> GetGameAsyncByFriend(int FriendId);
         Task<GameRented[]> GetAllGameRentedAsync();
         Task<GameRented> GetGameRentedAsyncById(int GameRentedId);
    }
}