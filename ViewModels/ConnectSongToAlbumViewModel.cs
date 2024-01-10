using CSharpLes42;
using Eindopdracht.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Eindopdracht.ViewModels
{
    public class ConnectSongToAlbumViewModel : ViewModelBase
    {
        private readonly MyDbContext _db;
        public ObservableCollection<Song> Songs
        {
            get { return _songs; }
            set
            {
                _songs = value;
                OnPropertyChanged(nameof(Songs));
            }
        }
        public ObservableCollection<Album> ConnectedAlbums
        {
            get { return _connectedAlbums; }
            set
            {
                _connectedAlbums = value;
                OnPropertyChanged(nameof(ConnectedAlbums));
            }
        }
        public ObservableCollection<Album> Albums
        {
            get { return _albums; }
            set
            {
                _albums = value;
                OnPropertyChanged(nameof(Albums));
            }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                FilterSongs(_searchQuery);
            }
        }
        private Album _selectedConnectedAlbum;
        public Album SelectedConnectedAlbum
        {
            get { return _selectedConnectedAlbum; }
            set
            {
                _selectedConnectedAlbum = value;
                OnPropertyChanged(nameof(SelectedConnectedAlbum));
            }
        }

        private ICollectionView _songsView;
        private ICollectionView _albumsView;

        private ObservableCollection<Song> _songs { get; set; }
        public ObservableCollection<Album> _albums { get; set; }
        public ObservableCollection<Album> _connectedAlbums { get; set; }

        public RelayCommand SaveChangesCommand { get; set; }
        public RelayCommand AddAlbumCommand { get; set; }
        public RelayCommand RemoveAlbumCommand { get; set; }


        private Song _selectedSong;
        public Song SelectedSong
        {
            get { return _selectedSong; }
            set
            {
                _selectedSong = value;
                OnPropertyChanged(nameof(SelectedSong));
                UpdateConnectedAlbums();

            }
        }
        private Album _selectedAlbum;
        public Album SelectedAlbum
        {
            get { return _selectedAlbum; }
            set
            {
                _selectedAlbum = value;
                OnPropertyChanged(nameof(SelectedAlbum));
            }
        }

        public ConnectSongToAlbumViewModel(MyDbContext db)
        {
            _db = db;

            Songs = new ObservableCollection<Song>(_db.Songs
                    .Include(h => h.Albums)
                    .ToList());
            Albums = new ObservableCollection<Album>(_db.Albums);
            _songsView = CollectionViewSource.GetDefaultView(Songs);
            _albumsView = CollectionViewSource.GetDefaultView(Albums);
            AddAlbumCommand = new RelayCommand(AddAlbum);
            RemoveAlbumCommand = new RelayCommand(RemoveAlbum);

            SaveChangesCommand = new RelayCommand(Save);


        }
        private void Save(object parameter)
        {

            _db.SaveChanges();


        }

        private void FilterSongs(string searchQuery)
        {
            _songsView.Filter = item =>
            {
                var song = item as Song;

                return song.Title.ToLower().Contains(searchQuery.ToLower())
                    || song.Artist.ToLower().Contains(searchQuery.ToLower())
                    || song.Genre.ToLower().Contains(searchQuery.ToLower());
            };
            _albumsView.Filter = item =>
            {
                var album = item as Album;

                return album.Title.ToLower().Contains(searchQuery.ToLower());
            };
        }
        private void UpdateConnectedAlbums()
        {
            if (SelectedSong != null)
            {
                ConnectedAlbums = new ObservableCollection<Album>(
                    _db.Songs
                        .Include(s => s.Albums)
                        .Where(s => s.Id == SelectedSong.Id)
                        .SelectMany(s => s.Albums)
                        .ToList());
            }
        }
        private void AddAlbum(object parameter)
        {
            if (SelectedSong != null && SelectedAlbum != null)
            {
                if (SelectedSong.Albums == null)
                {
                    SelectedSong.Albums = new ObservableCollection<Album>();
                }

                SelectedSong.Albums.Add(SelectedAlbum);

                _db.SaveChanges();

                UpdateConnectedAlbums();
            }
        }
        private void RemoveAlbum(object parameter)
        {
            if (SelectedSong != null && SelectedConnectedAlbum != null)
            {
                if (SelectedSong.Albums != null && SelectedSong.Albums.Contains(SelectedConnectedAlbum))
                {
                    SelectedSong.Albums.Remove(SelectedConnectedAlbum);

                    _db.SaveChanges();

                    UpdateConnectedAlbums();
                }
            }
        }
    }
}
