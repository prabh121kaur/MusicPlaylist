using CoreEntityFramework.Models;
using CoreEntityFramework.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            var songs = await _songService.GetSongsAsync();
            return Ok(songs);
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        // POST: api/Songs
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            var createdSong = await _songService.CreateSongAsync(song);
            return CreatedAtAction(nameof(GetSong), new { id = createdSong.SongId }, createdSong);
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.SongId)
            {
                return BadRequest();
            }

            try
            {
                await _songService.UpdateSongAsync(id, song);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            await _songService.DeleteSongAsync(id);
            return NoContent();
        }
    }
}
