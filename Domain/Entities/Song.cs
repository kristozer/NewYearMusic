using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace NewYearMusic.Domain.Entities
{
    public class Song : BaseEntity
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public IdentityUser User { get; private set; }

        protected Song() {}
        public Song(string name, string author, IdentityUser user)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            Name = name;
            Author = author;
            User = user;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            Name = name;
        }
        public void ChangeAuthor(string author)
        {
            Author = author;
        }
    }
}