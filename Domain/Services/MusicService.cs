using System.Threading.Tasks;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.Domain.Specifications;

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
        public async Task DeleteSong(Song song)
        {
            if (song.Id > 0)
                await _songRepository.DeleteAsync(song);

        }
        public async Task<Song> GetSongById(int id) => await _songRepository.GetByIdAsync(id);
        public async Task UpdateSong(Song song) => await _songRepository.UpdateAsync(song);
    }
}