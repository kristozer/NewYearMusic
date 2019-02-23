using System.Threading.Tasks;
using NewYearMusic.Domain.Entities;

namespace NewYearMusic.Domain.Interfaces
{
    public interface IMusicService
    {
         Task SaveSong(Song song);
    }
}