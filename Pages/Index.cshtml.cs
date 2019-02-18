using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewYearMusic.Data;
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
        public IEnumerable<SongViewModel> OnGet()
        {
            return _context.Songs.Include(x=>x.User).AsNoTracking()
            .Select(x=> new SongViewModel{SongId = x.SongId, Author = x.Author, Name = x.Name, User = x.User.UserName})
            .ToList();
        }
    }
}
