using System.Threading.Tasks;
using NewYearMusic.Web.ViewModels;

namespace NewYearMusic.Web.Interfaces
{
    public interface ICatalogService
    {
         Task<SongViewModel> GetSongs(string userName);
         Task<SongItemViewModel> GetSong(int id);
    }
}