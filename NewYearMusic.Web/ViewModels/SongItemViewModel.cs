using System;
using System.ComponentModel;

namespace NewYearMusic.Web.ViewModels
{
    public class SongItemViewModel
    {
        public int Id { get; set; }
        [DisplayName("Автор")]
        public string Author { get; set; }
        [DisplayName("Наименование")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Дата редактирования")]
        public DateTime EditionDate { get; set; }
        [DisplayName("Пользователь")]
        public string User { get; set; }
    }
}