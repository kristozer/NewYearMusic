using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.Domain.Specifications;
using NewYearMusic.Web.Interfaces;
using NewYearMusic.Web.ViewModels;

namespace NewYearMusic.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IRepositoryAsync<Song> _songRepository;
        public CatalogService(IRepositoryAsync<Song> songRepository)
        {
            _songRepository = songRepository;
        }
        public async Task<SongViewModel> GetSongs(string userName)
        {
            var songFilterSpec = new SongFilterSpecification(userName);
            var songs = await _songRepository.ListAsync(songFilterSpec);
            return new SongViewModel()
            {
                Songs = Mapper.Map<IReadOnlyList<Song>, IEnumerable<SongItemViewModel>>(songs)
            };
        }
        public async Task<SongItemViewModel> GetSong(int id)
        {
            var songFilterSpec = new SongFilterSpecification(id: id);
            var song = await _songRepository.GetByIdAsync(id, songFilterSpec);
            return Mapper.Map<Song, SongItemViewModel>(song);
        }
    }
}