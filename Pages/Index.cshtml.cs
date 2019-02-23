using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ApplicationDbContext _context;
        private readonly ICatalogService _catalogService;
        public IndexModel(ICatalogService catalogService) => _catalogService = catalogService;
        public SongViewModel SongModel { get; set; } = new SongViewModel();
        public async Task OnGet()
        {
            // SongModel.Songs = _context.Songs.Include(x => x.User).AsNoTracking()
            // .Select(x => new SongItemViewModel { Id = x.Id, Author = x.Author, Name = x.Name, User = x.User.UserName })
            // .ToList();
            var user = new AppUser();
            SongModel = await _catalogService.GetSongs(user);
        }
        public async Task OnPost()
        {
            RedirectToPage("/Index");
        }
    }
}
