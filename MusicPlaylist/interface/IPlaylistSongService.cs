using CoreEntityFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreEntityFramework.Services
{
    public interface IPlaylistSongService
    {
        Task AddSongToPlaylistAsync(int playlistId, int songId);
        Task RemoveSongFromPlaylistAsync(int playlistId, int songId);
        Task<IEnumerable<PlaylistSong>> GetPlaylistSongsAsync(); // List all songs in playlists
        Task<PlaylistSong?> GetPlaylistSongAsync(int playlistId, int songId); // Get a specific song in a playlist
        Task UpdatePlaylistSongAsync(PlaylistSong playlistSong); // Update a specific playlist song
    }
}
