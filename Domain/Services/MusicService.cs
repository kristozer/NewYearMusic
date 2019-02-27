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
        public async Task SaveSongAsync(Song song)
        {
            if (song.Name != null)
                await _songRepository.AddAsync(song);
        }
        public async Task DeleteSongAsync(Song song)
        {
            await _songRepository.DeleteAsync(song);
        }
        public async Task<Song> GetSongByIdAsync(int id) => await _songRepository.GetByIdAsync(id);
        public async Task<Song> GetSongWithUserByIdAsync(int id)
        {
            var songFilterSpec = new SongFilterSpecification(id: id);
            return await _songRepository.GetByIdAsync(id, songFilterSpec);
        }
        public async Task UpdateSongAsync(Song song) => await _songRepository.UpdateAsync(song);
    }
}