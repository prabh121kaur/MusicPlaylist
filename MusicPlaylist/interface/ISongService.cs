using CoreEntityFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreEntityFramework.Services
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> GetSongsAsync();
        Task<Song> GetSongByIdAsync(int id);
        Task<Song> CreateSongAsync(Song song);
        Task UpdateSongAsync(int id, Song song);
        Task DeleteSongAsync(int id);
        bool SongExists(int id);
    }
}
