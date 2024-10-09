using System.Threading.Tasks;

namespace CoreEntityFramework.Interfaces
{
    public interface IFavoriteSongsService
    {
        Task AddFavoriteSongAsync(int userId, int songId);
        Task RemoveFavoriteSongAsync(int userId, int songId);
    }
}
