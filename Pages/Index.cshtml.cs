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
using NewYearMusic.Infrastructure.Data;
using NewYearMusic.Infrastructure.Identity;
using NewYearMusic.ViewModels;

namespace NewYearMusic.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICatalogService _catalogService;
        private readonly IMusicService _musicService;
        public IndexModel(UserManager<AppUser> userManager,
            ICatalogService catalogService,
            IMusicService musicService)
        {
            _userManager = userManager;
            _catalogService = catalogService;
            _musicService = musicService;
        }
        public SongViewModel SongModel { get; set; } = new SongViewModel();
        public async Task OnGet(string userName)
        {
            SongModel = await _catalogService.GetSongs(userName);
        }
        public async Task<IActionResult> OnPost(Song song)
        {
            if (User.Identity.IsAuthenticated)//TODO проверка на пустые поля, заносить без названия песни или группы
            {
                song.User = await _userManager.GetUserAsync(User);
                if (song.User != null) await _musicService.SaveSongAsync(song);
            }
            return RedirectToPage();
        }
    }
}
