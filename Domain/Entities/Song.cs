using NewYearMusic.Infrastructure.Identity;

namespace NewYearMusic.Domain.Entities
{
    public class Song : BaseEntity
    {
        public int SongId{get;set;}
        public string Author { get; set; }
        public string Name { get; set; }
        public string AppUserId { get; set; }
        public AppUser User { get; set; }
    }
}