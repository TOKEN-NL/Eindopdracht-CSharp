using CSharpLes42;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Eindopdracht.Models;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Eindopdracht.ViewModels
{
    public class AddSongViewModel : ViewModelBase
    {
        private readonly MyDbContext _db;
        public ObservableCollection<Song> Songs { get; set; }
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private string _artist;
        public string Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                _artist = value;
                OnPropertyChanged(nameof(Artist));
            }
        }
        private string _album;
        public string Album
        {
            get
            {
                return _album;
            }
            set
            {
                _album = value;
                OnPropertyChanged(nameof(Album));
            }
        }

        public RelayCommand SaveSongCommand { get; set; }

        
        public AddSongViewModel(MyDbContext db)
        {
            _db = db;
            Songs = new ObservableCollection<Song>(_db.Songs);
            SaveSongCommand = new RelayCommand(SaveSong);

        }
        private void SaveSong(object parameter)
        {
            var newSong = new Song
            {
                Title = _title,
                Genre = "Rock",
                DurationInSeconds = 234,
                ReleaseDate = new DateTime(20000)
            };

            _db.Songs.Add(newSong);
            _db.SaveChanges();

            Songs.Add(newSong);
            System.Windows.MessageBox.Show("Het liedje is succesvol toegevoegd!", "Succes");

        }
    }
    
}
