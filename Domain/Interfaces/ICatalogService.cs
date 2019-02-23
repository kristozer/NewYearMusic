using System.Threading.Tasks;
using NewYearMusic.ViewModels;

namespace NewYearMusic.Domain.Interfaces
{
    public interface ICatalogService
    {
         Task<SongViewModel> GetSongs(string userName);
    }
}