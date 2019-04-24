using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;

namespace NewYearMusic.Domain.Entities
{
    public class Song : BaseEntity
    {

        [DisplayName("������������")]
        public string Name { get; private set; }

        [DisplayName("�����")]
        public string Author { get; private set; }

        [DisplayName("��������")]
        public string Description { get; private set; }

        [DisplayName("���� ��������������")]
        public DateTime EditionDate { get; private set; }

        [DisplayName("������������")]
        public string AppUserId { get; private set; }
        public AppUser AppUser { get; set; }

        protected Song() { }
        public Song(string name, AppUser appUser, DateTime editionDate, string author = null, string description = null)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            Name = name;
            Author = author;
            AppUser = appUser ?? throw new ArgumentNullException(nameof(appUser));
            Description = description;
            EditionDate = editionDate;
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
        public void ChangeDescription(string description)
        {
            Description = description;
        }
        public void ChangeEditionDate(DateTime editionDate)
        {
            EditionDate = editionDate;
        }
    }
}