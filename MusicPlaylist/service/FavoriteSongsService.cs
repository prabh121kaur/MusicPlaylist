using CoreEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreEntityFramework.Services
{
    public class FavoriteSongService : IFavoriteSongService
    {
        private readonly AppDbContext _context;

        public FavoriteSongService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FavoriteSong>> GetAllFavoriteSongsAsync()
        {
            return await _context.FavoriteSongs.ToListAsync();
        }

        public async Task<FavoriteSong> GetFavoriteSongByIdAsync(int id)
        {
            return await _context.FavoriteSongs.FindAsync(id);
        }

        public async Task UpdateFavoriteSongAsync(FavoriteSong favoriteSong)
        {
            _context.Entry(favoriteSong).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Keep existing methods
        public async Task AddFavoriteSongAsync(int userId, int songId)
        {
            // Your existing implementation
        }

        public async Task RemoveFavoriteSongAsync(int userId, int songId)
        {
            // Your existing implementation
        }
    }
}
