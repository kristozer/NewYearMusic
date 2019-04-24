using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewYearMusic.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Songs = new List<Song>();
        }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
