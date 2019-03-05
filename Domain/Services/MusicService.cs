using System.Threading.Tasks;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.Domain.Specifications;

namespace NewYearMusic.Domain.Services
{
    public class MusicService : IMusicService
    {
        private readonly IRepositoryAsync<Song> _songRepository;
        private readonly IAppLogger<MusicService> _logger;
        public MusicService(IRepositoryAsync<Song> songRepository,
        IAppLogger<MusicService> logger)
        {
            _songRepository = songRepository;
            _logger = logger;
        }
        public async Task SaveSongAsync(Song song)
        {
            _logger.LogInformation("MusicService.SaveSongAsync called");
            if (song.Name != null)
                await _songRepository.AddAsync(song);
        }
        public async Task DeleteSongAsync(Song song)
        {
            _logger.LogInformation("MusicService.DeleteSongAsync called");
            await _songRepository.DeleteAsync(song);
        }
        public async Task<Song> GetSongByIdAsync(int id)
        {
            _logger.LogInformation("MusicService.GetSongByIdAsync called");
            return await _songRepository.GetByIdAsync(id);
        }
        public async Task<Song> GetSongWithUserByIdAsync(int id)
        {
            _logger.LogInformation("MusicService.GetSongWithUserByIdAsync called");
            var songFilterSpec = new SongFilterSpecification(id: id);
            return await _songRepository.GetByIdAsync(id, songFilterSpec);
        }
        public async Task UpdateSongAsync(Song song)
        {
            _logger.LogInformation("MusicService.UpdateSongAsync called");
             await _songRepository.UpdateAsync(song);
        }
    }
}