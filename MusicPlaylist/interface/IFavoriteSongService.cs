using CoreEntityFramework.Models;
using System.Threading.Tasks;

namespace CoreEntityFramework.Services
{
    /*  public interface IFavoriteSongService
      {
          Task AddFavoriteSongAsync(int userId, int songId);
          Task RemoveFavoriteSongAsync(int userId, int songId);
      }
  }*/
    public interface IFavoriteSongService
    {
        Task<IEnumerable<FavoriteSong>> GetAllFavoriteSongsAsync();
        Task<FavoriteSong> GetFavoriteSongByIdAsync(int id);
        Task AddFavoriteSongAsync(int userId, int songId);
        Task UpdateFavoriteSongAsync(FavoriteSong favoriteSong);
        Task RemoveFavoriteSongAsync(int userId, int songId);
    }
}