using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.Web.Interfaces;

namespace NewYearMusic.Web.Controllers
{
    public class SongManageController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IMusicService _musicService;

        public SongManageController(ICatalogService catalogService, IMusicService musicService)
        {
            _catalogService = catalogService;
            _musicService = musicService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id, string actionHandler)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _catalogService.GetSong((int)id);

            if (song == null)
            {
                return NotFound();
            }

            ViewData["ActionName"] = actionHandler == "update" ? "Изменить" : "Удалить";
            ViewData["Action"] = actionHandler == "update" ? "UpdateAsync" : "DeleteAsync";

            return View("View", song);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(Song _song)
        {
            var res = ValidateAfterBinding(_song);
            if (res != null) return res;
            await _musicService.UpdateSongAsync(_song);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Song _song)
        {
            var res = ValidateAfterBinding(_song);
            if (res != null) return res;
            await _musicService.DeleteSongAsync(_song);
            return RedirectToAction("Index", "Home");
        }

        private IActionResult ValidateAfterBinding(Song song)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction();
            }
            if (song == null)
            {
                return NotFound();
            }
            return null;
        }
    }
}