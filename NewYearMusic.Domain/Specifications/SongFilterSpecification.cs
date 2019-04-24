using NewYearMusic.Domain.Entities;

namespace NewYearMusic.Domain.Specifications
{
    public sealed class SongFilterSpecification : BaseSpecification<Song>
    {
        public SongFilterSpecification(string userName = null, int? id = null)
        : base(i => (string.IsNullOrEmpty(userName) || i.AppUser.UserName == userName) && 
        (id == null || i.Id == id))
        {
            AddInclude(x => x.AppUser);
        }
    }
}