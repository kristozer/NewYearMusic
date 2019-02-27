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
        private Song _song;
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
            var res = await ValidateRequestAsync();
            if (res != null) return res;
            await _musicService.UpdateSongAsync(_song);
            return RedirectToPage("/Index");
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var res = await ValidateRequestAsync();
            if (res != null) return res;
            await _musicService.DeleteSongAsync(_song);
            return RedirectToPage("/Index");
        }
        private async Task<IActionResult> ValidateRequestAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            _song = await _musicService.GetSongWithUserByIdAsync(Song.Id);
            if (_song == null)
            {
                return NotFound();
            }
            return null;
        }
    }
}