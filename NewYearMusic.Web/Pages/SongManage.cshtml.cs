using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NewYearMusic.Web.Infrastructure.ModelBinders;
using NewYearMusic.Web.Interfaces;

namespace NewYearMusic.Web.Pages
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
        public SongItemViewModel Song { get; private set; }
        public async Task<IActionResult> OnGetAsync(int? id, string handler)
        {
            ViewData["ActionName"] = handler == "update" ? "Изменить" : "Удалить";
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
            var res = ValidateAfterBinding(_song);
            if (res != null) return res;
            await _musicService.UpdateSongAsync(_song);
            return RedirectToPage("/Index");
        }
        public async Task<IActionResult> OnPostDeleteAsync(Song _song)
        {
            var res = ValidateAfterBinding(_song);
            if (res != null) return res;
            await _musicService.DeleteSongAsync(_song);
            return RedirectToPage("/Index");
        }
        private IActionResult ValidateAfterBinding(Song song)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (song == null)
            {
                return NotFound();
            }
            return null;
        }
    }
}