using CSharpLes42;
using Eindopdracht.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Eindopdracht.ViewModels
{
    public class AddAlbumViewModel : ViewModelBase
    {
        private readonly MyDbContext _db;
        public ObservableCollection<Song> Songs { get; set; }
        public ObservableCollection<Album> Albums { get; set; }

        private string _title;
        private int _releaseYear;
        private string _coverImage;
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
        public int ReleaseYear
        {
            get
            {
                return _releaseYear;
            }
            set
            {
                _releaseYear = value;
                OnPropertyChanged(nameof(ReleaseYear));
            }
        }

        public string CoverImage
        {
            get
            {
                return _coverImage;
            }
            set
            {
                _coverImage = value;
                OnPropertyChanged(nameof(CoverImage));
            }
        }


        public RelayCommand SaveAlbumCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }


        public AddAlbumViewModel(MyDbContext db)
        {
            _db = db;
            Songs = new ObservableCollection<Song>(_db.Songs);
            Albums = new ObservableCollection<Album>(_db.Albums);
            SaveAlbumCommand = new RelayCommand(SaveAlbum);
            CancelCommand = new RelayCommand(Cancel);

        }
        private void SaveAlbum(object parameter)
        {
            var newAlbum = new Album
            {
                Title = _title,
                ReleaseYear = _releaseYear,
                CoverImage = _coverImage,

            };


            _db.Albums.Add(newAlbum);
            _db.SaveChanges();

            Albums.Add(newAlbum);
            System.Windows.MessageBox.Show($"The album '{newAlbum.Title}' released in '{newAlbum.ReleaseYear}' has been added successfully!", "Succes");

        }
        private void Cancel(object parameter)
        {
            ((MainWindow)Application.Current.MainWindow).MainView();
        }

    }

}
