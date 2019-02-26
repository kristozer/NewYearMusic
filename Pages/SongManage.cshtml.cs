using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.ViewModels;
namespace NewYearMusic.Pages
{
    public class SongManageModel : PageModel
    {
        private readonly ICatalogService _catalogService;
        private readonly IMusicService _musicService;

        public SongManageModel(ICatalogService catalogService, IMusicService musicService)
        {
            _catalogService = catalogService;
            _musicService = musicService;
        }
        public string Action { get; set; }
        [BindProperty]
        public SongItemViewModel Song { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id, string action)
        {
            Action = action;
            if (id == null)
            {
                NotFound();
            }
            Song = await _catalogService.GetSong((int)id);
            if (Song == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var song = await _musicService.GetSongById(Song.Id);
            if (User.Identity.IsAuthenticated && !string.IsNullOrEmpty(Action))
            {
                if (song.Id > 0) await _musicService.UpdateSong(song);
            }
            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var song = await _musicService.GetSongById(Song.Id);
            if (User.Identity.IsAuthenticated && !string.IsNullOrEmpty(Action))
            {
                if (song.Id > 0) await _musicService.DeleteSong(song);
            }
            return RedirectToPage("Index");
        }
    }
}