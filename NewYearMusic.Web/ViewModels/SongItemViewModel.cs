using System;
using System.ComponentModel;

namespace NewYearMusic.Web.ViewModels
{
    public class SongItemViewModel
    {
        public int Id { get; set; }
        [DisplayName("�����")]
        public string Author { get; set; }
        [DisplayName("������������")]
        public string Name { get; set; }
        [DisplayName("��������")]
        public string Description { get; set; }
        [DisplayName("���� ��������������")]
        public DateTime EditionDate { get; set; }
        [DisplayName("������������")]
        public string User { get; set; }
    }
}