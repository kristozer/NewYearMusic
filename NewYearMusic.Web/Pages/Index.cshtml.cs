using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.Data;
using NewYearMusic.Web.ViewModels;
using NewYearMusic.Web.Interfaces;

namespace NewYearMusic.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogService _catalogService;
        private readonly IMusicService _musicService;
        public IndexModel(ICatalogService catalogService,
            IMusicService musicService)
        {
            _catalogService = catalogService;
            _musicService = musicService;
        }
        public SongViewModel SongModel { get; set; } = new SongViewModel();
        public async Task OnGet()
        {
            SongModel = await _catalogService.GetSongs(string.Empty);
        }
        public async Task<IActionResult> OnPost(Song song)
        {
            if (!ModelState.IsValid) return RedirectToPage();
            if (song != null)
                await _musicService.SaveSongAsync(song);
            return RedirectToPage();
        }
    }
}
