using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_KB_2024.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DurationInSeconds { get; set; }

        // Songs kunnen op meerdere Albums voorkomen, vandaar een lijst met AlbumIds
        public List<int> AlbumIds { get; set; }
    }
}
