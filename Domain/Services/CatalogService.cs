using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            return new SongViewModel()
            {
                Songs = Mapper.Map<IReadOnlyList<Song>, IEnumerable<SongItemViewModel>>(songs)
            };
        }
        public async Task<SongItemViewModel> GetSong(int id)
        {
            _logger.LogInformation("CatalogService.GetSong called");
            var songFilterSpec = new SongFilterSpecification(id: id);
            var song = await _songRepository.GetByIdAsync(id, songFilterSpec);
            return Mapper.Map<Song, SongItemViewModel>(song);
        }
    }
}