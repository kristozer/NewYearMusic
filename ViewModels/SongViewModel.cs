using System.Collections.Generic;

namespace NewYearMusic.ViewModels
{
    public class SongViewModel
    {
        public IEnumerable<SongItemViewModel> Songs { get; set; }
    }
}