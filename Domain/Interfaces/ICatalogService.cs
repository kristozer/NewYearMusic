using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NewYearMusic.ViewModels;

namespace NewYearMusic.Domain.Interfaces
{
    public interface ICatalogService
    {
         Task<SongViewModel> GetSongs(IdentityUser user);
    }
}