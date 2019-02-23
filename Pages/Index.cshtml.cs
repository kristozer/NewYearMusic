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
        public IndexModel(UserManager<AppUser> userManager, ICatalogService catalogService)
        {
            _userManager = userManager;
            _catalogService = catalogService;
        }
        public SongViewModel SongModel { get; set; } = new SongViewModel();
        public async Task OnGet()
        {
            var userName = User.Identity.Name ?? "";
            SongModel = await _catalogService.GetSongs(userName);
        }
        public async Task<IActionResult> OnPost(Song song)
        {
            if(User.Identity.IsAuthenticated)
            song.User = await _userManager.GetUserAsync(User);

            return RedirectToPage();
        }
    }
}
