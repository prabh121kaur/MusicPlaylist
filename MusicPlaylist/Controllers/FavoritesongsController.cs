using CoreEntityFramework.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CoreEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteSongsController : ControllerBase
    {
        private readonly IFavoriteSongService _favoriteSongService;

        public FavoriteSongsController(IFavoriteSongService favoriteSongService)
        {
            _favoriteSongService = favoriteSongService;
        }

        // POST: api/FavoriteSongs
        [HttpPost]
        public async Task<ActionResult> AddFavoriteSong(int userId, int songId)
        {
            try
            {
                // Validate input
                if (userId <= 0 || songId <= 0)
                {
                    return BadRequest("Invalid userId or songId. Please provide valid values.");
                }

                // Attempt to add the favorite song
                await _favoriteSongService.AddFavoriteSongAsync(userId, songId);
                return Ok("Favorite song added successfully.");
            }
            catch (ArgumentException ex)
            {
                // Handle invalid userId or songId scenario
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Handle case where song is already marked as favorite
                return Conflict(ex.Message);
            }
            catch (DbUpdateException dbEx)
            {
                // Specific exception for database issues
                return StatusCode(500, $"Database error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                // General exception
                return StatusCode(500, $"An error occurred while adding the favorite song: {ex.Message}");
            }
        }

        // DELETE: api/FavoriteSongs/{userId}/{songId}
        [HttpDelete("{userId}/{songId}")]
        public async Task<IActionResult> RemoveFavoriteSong(int userId, int songId)
        {
            try
            {
                // Validate input
                if (userId <= 0 || songId <= 0)
                {
                    return BadRequest("Invalid userId or songId. Please provide valid values.");
                }

                await _favoriteSongService.RemoveFavoriteSongAsync(userId, songId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                // Handle invalid userId or songId scenario
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException dbEx)
            {
                // Specific exception for database issues
                return StatusCode(500, $"Database error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                // General exception
                return StatusCode(500, $"An error occurred while removing the favorite song: {ex.Message}");
            }
        }
    }
}
