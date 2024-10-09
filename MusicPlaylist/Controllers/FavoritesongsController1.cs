using CoreEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteSongsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteSongsController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/FavoriteSongs
        [HttpPost]
        public async Task<ActionResult> AddFavoriteSong(int userId, int songId)
        {
            var favoriteSong = new FavoriteSong
            {
                UserId = userId,
                SongId = songId
            };

            _context.FavoriteSongs.Add(favoriteSong);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/FavoriteSongs
        [HttpDelete("{userId}/{songId}")]
        public async Task<IActionResult> RemoveFavoriteSong(int userId, int songId)
        {
            var favoriteSong = await _context.FavoriteSongs
                .FirstOrDefaultAsync(fs => fs.UserId == userId && fs.SongId == songId);

            if (favoriteSong == null)
            {
                return NotFound();
            }

            _context.FavoriteSongs.Remove(favoriteSong);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
