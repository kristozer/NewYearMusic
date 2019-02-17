using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace NewYearMusic.Infrastructure.Identity
{
    public class AppUser : IdentityUser
    {
        public List<Song> Songs { get; set; }
        public AppUser()
        {
            Songs = new List<Song>();
        }
    }
}