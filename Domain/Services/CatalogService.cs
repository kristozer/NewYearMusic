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
        public CatalogService(IRepositoryAsync<Song> songRepository) => _songRepository = songRepository;
        public async Task<SongViewModel> GetSongs(string userName)
        {
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
    }
}