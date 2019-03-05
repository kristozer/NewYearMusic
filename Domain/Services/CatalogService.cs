using System.Linq;
using System.Threading.Tasks;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.Domain.Specifications;
using NewYearMusic.ViewModels;

namespace NewYearMusic.Domain.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IRepositoryAsync<Song> _songRepository;
        private readonly IAppLogger<CatalogService> _logger;
        public CatalogService(IRepositoryAsync<Song> songRepository, 
        IAppLogger<CatalogService> logger) 
        {
            _songRepository = songRepository;
            _logger = logger;
        }
        public async Task<SongViewModel> GetSongs(string userName)
        {
            _logger.LogInformation("CatalogService.GetSongs called");
            var songFilterSpec = new SongFilterSpecification(userName);
            var songs = await _songRepository.ListAsync(songFilterSpec);
            var vm = new SongViewModel()
            {
                Songs = songs.Select(i => new SongItemViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Author = i.Author,
                    User = i.User.UserName
                })
            };
            return vm;
        }
        public async Task<SongItemViewModel> GetSong(int id)
        {
            _logger.LogInformation("CatalogService.GetSong called");
            var songFilterSpec = new SongFilterSpecification(id: id);
            var song = await _songRepository.GetByIdAsync(id, songFilterSpec);
            var vmi = new SongItemViewModel()
            {
                Id = song.Id, Name=song.Name, Author=song.Author, User=song.User.UserName
            };
            return vmi;
        }
    }
}