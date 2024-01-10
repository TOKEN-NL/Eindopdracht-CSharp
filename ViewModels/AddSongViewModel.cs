using CSharpLes42;
using Eindopdracht.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Eindopdracht.ViewModels
{
    public class AddSongViewModel : ViewModelBase
    {
        private readonly MyDbContext _db;
        public ObservableCollection<Song> Songs { get; set; }
        public ObservableCollection<Album> Albums { get; set; }

        private string _title;
        private string _artist;
        private string _genre;
        private int _durationIS;
        private DateOnly _releaseDate;


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

        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }
        public int DurationIS
        {
            get
            {
                return _durationIS;
            }
            set
            {
                _durationIS = value;
                OnPropertyChanged(nameof(DurationIS));
            }
        }
        public DateOnly ReleaseDate
        {
            get
            {
                return _releaseDate;
            }
            set
            {
                _releaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }

        public RelayCommand SaveSongCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }


        public AddSongViewModel(MyDbContext db)
        {
            _db = db;
            Songs = new ObservableCollection<Song>(_db.Songs);
            Albums = new ObservableCollection<Album>(_db.Albums);
            SaveSongCommand = new RelayCommand(SaveSong);
            CancelCommand = new RelayCommand(Cancel);

        }
        private void SaveSong(object parameter)
        {
            var newSong = new Song
            {
                Title = _title,
                Genre = _genre,
                DurationInSeconds = _durationIS,
                Artist = _artist,
                ReleaseDate = new DateTime(20000),
            };


            _db.Songs.Add(newSong);
            _db.SaveChanges();

            Songs.Add(newSong);
            System.Windows.MessageBox.Show($"The song '{newSong.Title}' by '{newSong.Artist}' has been added successfully!", "Succes");

        }
        private void Cancel(object parameter)
        {
            ((MainWindow)Application.Current.MainWindow).MainView();
        }

    }

}
