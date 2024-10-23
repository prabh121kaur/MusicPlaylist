using CoreEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreEntityFramework.Services
{
    public class PlaylistSongService : IPlaylistSongService
    {
        private readonly AppDbContext _context;

        public PlaylistSongService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddSongToPlaylistAsync(int playlistId, int songId)
        {
            var playlistSong = new PlaylistSong
            {
                PlaylistId = playlistId,
                SongId = songId
            };

            _context.PlaylistSongs.Add(playlistSong);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveSongFromPlaylistAsync(int playlistId, int songId)
        {
            var playlistSong = await _context.PlaylistSongs
                .FirstOrDefaultAsync(ps => ps.PlaylistId == playlistId && ps.SongId == songId);

            if (playlistSong != null)
            {
                _context.PlaylistSongs.Remove(playlistSong);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PlaylistSong>> GetPlaylistSongsAsync()
        {
            return await _context.PlaylistSongs.ToListAsync();
        }

        public async Task<PlaylistSong?> GetPlaylistSongAsync(int playlistId, int songId)
        {
            return await _context.PlaylistSongs
                .FirstOrDefaultAsync(ps => ps.PlaylistId == playlistId && ps.SongId == songId);
        }

        public async Task UpdatePlaylistSongAsync(PlaylistSong playlistSong)
        {
            _context.PlaylistSongs.Update(playlistSong);
            await _context.SaveChangesAsync();
        }
    }
}
