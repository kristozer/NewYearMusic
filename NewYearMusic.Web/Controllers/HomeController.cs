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
    public class HomeController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IMusicService _musicService;

        public HomeController(ICatalogService catalogService,
            IMusicService musicService)
        {
            _catalogService = catalogService;
            _musicService = musicService;
        }

        public async Task<IActionResult> Index()
        {
            var songs = await _catalogService.GetSongs(string.Empty);
            return View(songs);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Song song)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (song != null)
                await _musicService.SaveSongAsync(song);

            return RedirectToAction();
        }
    }
}