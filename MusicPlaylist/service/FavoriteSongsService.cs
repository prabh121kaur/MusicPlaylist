using CoreEntityFramework.Interfaces;
using CoreEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreEntityFramework.Services
{
    public class FavoriteSongsService : IFavoriteSongsService
    {
        private readonly AppDbContext _context;

        public FavoriteSongsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddFavoriteSongAsync(int userId, int songId)
        {
            var favoriteSong = new FavoriteSong
            {
                UserId = userId,
                SongId = songId
            };

            _context.FavoriteSongs.Add(favoriteSong);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavoriteSongAsync(int userId, int songId)
        {
            var favoriteSong = await _context.FavoriteSongs
                .FirstOrDefaultAsync(fs => fs.UserId == userId && fs.SongId == songId);

            if (favoriteSong != null)
            {
                _context.FavoriteSongs.Remove(favoriteSong);
                await _context.SaveChangesAsync();
            }
        }
    }
}
