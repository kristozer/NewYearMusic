using Microsoft.AspNetCore.Identity;
using NewYearMusic.Domain.Entities;

namespace NewYearMusic.Domain.Specifications
{
    public sealed class SongFilterSpecification : BaseSpecification<Song>
    {
        public SongFilterSpecification(IdentityUser user)
        : base(i => string.IsNullOrEmpty(user.Id) || i.User.Id == user.Id)
        {
            AddInclude(x => x.User);
        }
    }
}