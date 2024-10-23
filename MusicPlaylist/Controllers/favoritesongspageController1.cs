using CoreEntityFramework.Models;
using CoreEntityFramework.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreEntityFramework.Controllers
{
    public class FavoritesongsController : Controller
    {
        private readonly IFavoriteSongService _favoriteSongService;

        public FavoritesongsController(IFavoriteSongService favoriteSongService)
        {
            _favoriteSongService = favoriteSongService;
        }

        // GET: FavoriteSongs
        public async Task<IActionResult> Index()
        {
            var favoriteSongs = await _favoriteSongService.GetAllFavoriteSongsAsync();
            return View(favoriteSongs);
        }

        // GET: FavoriteSongs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var favoriteSong = await _favoriteSongService.GetFavoriteSongByIdAsync(id);
            if (favoriteSong == null)
            {
                return NotFound();
            }
            return View(favoriteSong);
        }

        // GET: FavoriteSongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavoriteSongs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,SongId")] FavoriteSong favoriteSong)
        {
            if (ModelState.IsValid)
            {
                await _favoriteSongService.AddFavoriteSongAsync(favoriteSong.UserId, favoriteSong.SongId);
                return RedirectToAction(nameof(Index));
            }
            return View(favoriteSong);
        }

        // GET: FavoriteSongs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var favoriteSong = await _favoriteSongService.GetFavoriteSongByIdAsync(id);
            if (favoriteSong == null)
            {
                return NotFound();
            }
            return View(favoriteSong);
        }

        // POST: FavoriteSongs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoriteSongId,UserId,SongId")] FavoriteSong favoriteSong)
        {
            if (id != favoriteSong.FavoriteSongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _favoriteSongService.UpdateFavoriteSongAsync(favoriteSong);
                return RedirectToAction(nameof(Index));
            }
            return View(favoriteSong);
        }

        // GET: FavoriteSongs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var favoriteSong = await _favoriteSongService.GetFavoriteSongByIdAsync(id);
            if (favoriteSong == null)
            {
                return NotFound();
            }
            return View(favoriteSong);
        }

        // POST: FavoriteSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteSong = await _favoriteSongService.GetFavoriteSongByIdAsync(id);
            if (favoriteSong != null)
            {
                await _favoriteSongService.RemoveFavoriteSongAsync(favoriteSong.UserId, favoriteSong.SongId);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
