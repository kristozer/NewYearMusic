using Microsoft.AspNetCore.Mvc.ModelBinding;
using NewYearMusic.Infrastructure.Identity;

namespace NewYearMusic.Domain.Entities
{
    public class Song : BaseEntity
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string AppUserId { get; set; }
        [BindNever]
        public AppUser User { get; set; }
    }
}