using System.Threading.Tasks;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;

namespace NewYearMusic.Domain.Services
{
    public class MusicService : IMusicService
    {
        private readonly IRepositoryAsync<Song> _songRepository;
        public MusicService(IRepositoryAsync<Song> songRepository) => _songRepository = songRepository;
        public async Task SaveSong(Song song)
        {
            if (song.Name != null)
                await _songRepository.AddAsync(song);
        }
    }
}