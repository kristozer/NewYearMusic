using System.Collections.Generic;

namespace NewYearMusic.Web.ViewModels
{
    public class SongViewModel
    {
        public IEnumerable<SongItemViewModel> Songs { get; set; }
    }
}