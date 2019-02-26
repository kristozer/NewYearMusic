using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.ViewModels;
namespace NewYearMusic.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ICatalogService _catalogService;
        private readonly IMusicService _musicService;

        public DeleteModel(
            ICatalogService catalogService,
            IMusicService musicService)
        {
            _catalogService = catalogService;
            _musicService = musicService;
        }
        public SongItemViewModel Song{get;set;}
        public async Task OnGet(int id)
        {
            Song = await _catalogService.GetSong(id);
        }
        public async Task<IActionResult> OnPost(int id)
        {
            if (User.Identity.IsAuthenticated && id>0)
            {
                var song = await _musicService.GetSongById(id);
                if (song.Id >0) await _musicService.DeleteSong(song);
            }
            return RedirectToPage();
        }
    }
}