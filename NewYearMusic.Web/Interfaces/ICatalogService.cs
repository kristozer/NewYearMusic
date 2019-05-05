using System.Collections.Generic;
using System.Threading.Tasks;
using NewYearMusic.Web.ViewModels;

namespace NewYearMusic.Web.Interfaces
{
    public interface ICatalogService
    {
         Task<IEnumerable<SongItemViewModel>> GetSongs(string userName);
         Task<SongItemViewModel> GetSong(int id);
    }
}