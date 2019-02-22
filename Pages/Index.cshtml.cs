using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Infrastructure.Data;
using NewYearMusic.ViewModels;

namespace NewYearMusic.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public SongViewModel SongModel { get; set; } = new SongViewModel();
        public void OnGet()
        {
            SongModel.SongItems = _context.Songs.Include(x=>x.User).AsNoTracking()
            .Select(x=> new SongItemViewModel{SongId = x.SongId, Author = x.Author, Name = x.Name, User = x.User.UserName})
            .ToList();
        }
    }
}
