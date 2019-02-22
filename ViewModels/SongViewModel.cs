using System.Collections.Generic;

namespace NewYearMusic.ViewModels
{
    public class SongViewModel
    {
        public IEnumerable<SongItemViewModel> SongItems { get; set; }
    }
}