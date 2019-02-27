using System.Threading.Tasks;
using NewYearMusic.Domain.Entities;

namespace NewYearMusic.Domain.Interfaces
{
    public interface IMusicService
    {
         Task SaveSongAsync(Song song);
         Task DeleteSongAsync(Song song);
         Task<Song> GetSongByIdAsync(int id);
         Task<Song> GetSongWithUserByIdAsync(int id);
         Task UpdateSongAsync(Song song);
    }
}