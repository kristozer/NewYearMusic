using Microsoft.AspNetCore.Identity;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;
using NewYearMusic.Infrastructure.Identity;

namespace NewYearMusic.Domain.Specifications
{
    public sealed class SongFilterSpecification : BaseSpecification<Song>
    {
        public SongFilterSpecification(IAppUser user = null)
        : base(i => user == null || i.User == user)
        {
            AddInclude(x => x.User);
        }
    }
}