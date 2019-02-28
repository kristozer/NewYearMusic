using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NewYearMusic.Infrastructure.ModelBinders;

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
        [BindRequired]
        public string Action { get; set; }
        [BindNever]
        public string ActionName
        {
            get
            { return Action == "update" ? "Изменить" : "Удалить"; }
        }
        public SongItemViewModel Song { get; private set; }
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
        public async Task<IActionResult> OnPostUpdateAsync(Song _song)
        {
            var res = ValidateRequest(_song);
            if (res != null) return res;
            await _musicService.UpdateSongAsync(_song);
            return RedirectToPage("/Index");
        }
        public async Task<IActionResult> OnPostDeleteAsync(Song _song)
        {
            var res = ValidateRequest(_song);
            if (res != null) return res;
            await _musicService.DeleteSongAsync(_song);
            return RedirectToPage("/Index");
        }
        private IActionResult ValidateRequest(Song song)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            if (song == null)
            {
                return NotFound();
            }
            return null;
        }
    }
}