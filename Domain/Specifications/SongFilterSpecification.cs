using NewYearMusic.Domain.Entities;

namespace NewYearMusic.Domain.Specifications
{
    public sealed class SongFilterSpecification : BaseSpecification<Song>
    {
        public SongFilterSpecification(string userName)
        : base(i => string.IsNullOrEmpty(userName) || i.User.UserName == userName)
        {
            AddInclude(x => x.User);
        }
    }
}