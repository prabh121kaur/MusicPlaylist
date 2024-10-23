using CoreEntityFramework.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistSongsController : ControllerBase
    {
        private readonly IPlaylistSongService _playlistSongService;

        public PlaylistSongsController(IPlaylistSongService playlistSongService)
        {
            _playlistSongService = playlistSongService;
        }

        // POST: api/PlaylistSongs
        [HttpPost]
        public async Task<ActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            await _playlistSongService.AddSongToPlaylistAsync(playlistId, songId);
            return Ok();
        }

        // DELETE: api/PlaylistSongs/{playlistId}/{songId}
        [HttpDelete("{playlistId}/{songId}")]
        public async Task<IActionResult> RemoveSongFromPlaylist(int playlistId, int songId)
        {
            await _playlistSongService.RemoveSongFromPlaylistAsync(playlistId, songId);
            return NoContent();
        }
    }
}
