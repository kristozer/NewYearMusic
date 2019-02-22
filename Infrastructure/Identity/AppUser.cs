using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using NewYearMusic.Domain.Entities;
using NewYearMusic.Domain.Interfaces;

namespace NewYearMusic.Infrastructure.Identity
{
    public class AppUser : IdentityUser, IAppUser
    {
        public List<Song> Songs { get; set; }
        public AppUser()
        {
            Songs = new List<Song>();
        }
    }
}