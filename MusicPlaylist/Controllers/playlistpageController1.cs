using CoreEntityFramework.Models;
using CoreEntityFramework.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreEntityFramework.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        // GET: Playlists
        public async Task<IActionResult> Index()
        {
            var playlists = await _playlistService.GetPlaylistsAsync();
            return View(playlists);
        }

        // GET: Playlists/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // GET: Playlists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,PlaylistColor,IsPrivate,UserId")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                playlist.CreatedDate = DateTime.Now;
                await _playlistService.CreatePlaylistAsync(playlist);
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: Playlists/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaylistId,Name,Description,PlaylistColor,IsPrivate,UserId,CreatedDate")] Playlist playlist)
        {
            if (id != playlist.PlaylistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _playlistService.UpdatePlaylistAsync(id, playlist);
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: Playlists/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _playlistService.DeletePlaylistAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
