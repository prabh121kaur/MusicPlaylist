using CoreEntityFramework.Models;
using CoreEntityFramework.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CoreEntityFramework.Controllers
{
    [Route("PlaylistSongs")]
    public class PlaylistSongController : Controller
    {
        private readonly IPlaylistSongService _playlistSongService;

        public PlaylistSongController(IPlaylistSongService playlistSongService)
        {
            _playlistSongService = playlistSongService;
        }

        // GET: PlaylistSongs
        public async Task<IActionResult> Index()
        {
            var playlistSongs = await _playlistSongService.GetPlaylistSongsAsync();
            return View(playlistSongs);
        }

        // GET: PlaylistSongs/Details/5
        public async Task<IActionResult> Details(int playlistId, int songId)
        {
            var playlistSong = await _playlistSongService.GetPlaylistSongAsync(playlistId, songId);
            if (playlistSong == null)
            {
                return NotFound();
            }
            return View(playlistSong);
        }

        // GET: PlaylistSongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlaylistSongs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int playlistId, int songId)
        {
            if (ModelState.IsValid)
            {
                await _playlistSongService.AddSongToPlaylistAsync(playlistId, songId);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: PlaylistSongs/Edit/5
        public async Task<IActionResult> Edit(int playlistId, int songId)
        {
            var playlistSong = await _playlistSongService.GetPlaylistSongAsync(playlistId, songId);
            if (playlistSong == null)
            {
                return NotFound();
            }
            return View(playlistSong);
        }

        // POST: PlaylistSongs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int playlistId, int songId, PlaylistSong playlistSong)
        {
            if (ModelState.IsValid)
            {
                await _playlistSongService.UpdatePlaylistSongAsync(playlistSong);
                return RedirectToAction(nameof(Index));
            }
            return View(playlistSong);
        }

        // GET: PlaylistSongs/Delete/5
        public async Task<IActionResult> Delete(int playlistId, int songId)
        {
            var playlistSong = await _playlistSongService.GetPlaylistSongAsync(playlistId, songId);
            if (playlistSong == null)
            {
                return NotFound();
            }
            return View(playlistSong);
        }

        // POST: PlaylistSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int playlistId, int songId)
        {
            await _playlistSongService.RemoveSongFromPlaylistAsync(playlistId, songId);
            return RedirectToAction(nameof(Index));
        }
    }
}
