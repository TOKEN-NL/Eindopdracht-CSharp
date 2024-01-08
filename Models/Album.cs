using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_KB_2024.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string CoverImage { get; set; }
        public ObservableCollection<Song> Songs { get; set; } 
        public List<string> Artists { get; set; }
    }
}
