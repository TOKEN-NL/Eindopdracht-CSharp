using Eindopdracht.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DurationInSeconds { get; set; }

        // Songs kunnen op meerdere Albums voorkomen, vandaar een lijst met AlbumIds
        public ObservableCollection<Album> Albums { get; set; }
    }
}
