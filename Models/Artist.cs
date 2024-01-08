using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eindopdracht.Models;

namespace Eindopdracht.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ObservableCollection<Song> Songs { get; set; }
        public ObservableCollection<Album> Albums { get; set; }
    }
}
