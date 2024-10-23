using CoreEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreEntityFramework.Services
{
    public class SongService : ISongService
    {
        private readonly AppDbContext _context;

        public SongService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetSongsAsync()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song> GetSongByIdAsync(int id)
        {
            return await _context.Songs.FindAsync(id);
        }

        public async Task<Song> CreateSongAsync(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task UpdateSongAsync(int id, Song song)
        {
            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    throw new KeyNotFoundException("Song not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteSongAsync(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
            }
        }

        public bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }
    }
}
