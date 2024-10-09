using System.Threading.Tasks;

namespace CoreEntityFramework.Interfaces
{
    public interface IPlaylistSongsService
    {
        Task AddSongToPlaylistAsync(int playlistId, int songId);
        Task RemoveSongFromPlaylistAsync(int playlistId, int songId);
    }
}
