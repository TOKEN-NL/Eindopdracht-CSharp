using CSharpLes42;
using Eindopdracht.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Eindopdracht.ViewModels
{
    public class AllSongsViewModel : ViewModelBase
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
        private ICollectionView _songsView;
        private ObservableCollection<Song> _songs {  get; set; }
        public ObservableCollection<Album> Albums { get; set; }
        
        public RelayCommand SaveChangesCommand { get; set; }
        public RelayCommand RemoveSongCommand { get; set; }
        public RelayCommand AddSongCommand { get; set; }

        private Song _selectedSong;
        public Song SelectedSong
        {
            get { return _selectedSong; }
            set
            {
                _selectedSong = value;
                OnPropertyChanged(nameof(SelectedSong));
            }
        }

        public AllSongsViewModel(MyDbContext db)
        {
            _db = db;

            // Load Houses with related Landlords and Tenants
            Songs = new ObservableCollection<Song>(_db.Songs
                 //   .Include(h => h.Albums)
                    .ToList());
            Albums = new ObservableCollection<Album>(_db.Albums);
            SaveChangesCommand = new RelayCommand(Save);
            RemoveSongCommand = new RelayCommand(RemoveSong);
            AddSongCommand = new RelayCommand(AddSong);
            _songsView = CollectionViewSource.GetDefaultView(Songs);


        }
        private void Save(object parameter)
        {
            var selectedSongBeforeChanges = _db.Entry(SelectedSong).GetDatabaseValues().ToObject() as Song;

            _db.SaveChanges();

            var changedProperties = new List<string>();

            if (selectedSongBeforeChanges != null)
            {
                if (SelectedSong.Title != selectedSongBeforeChanges.Title)
                    changedProperties.Add("Title");

                if (SelectedSong.Artist != selectedSongBeforeChanges.Artist)
                    changedProperties.Add("Artist");

                if (SelectedSong.Genre != selectedSongBeforeChanges.Genre)
                    changedProperties.Add("Genre");

                if (SelectedSong.DurationInSeconds != selectedSongBeforeChanges.DurationInSeconds)
                    changedProperties.Add("Duration (in seconds)");

                if (SelectedSong.ReleaseDate != selectedSongBeforeChanges.ReleaseDate)
                    changedProperties.Add("ReleaseDate");

                var selectedAlbumsBeforeChanges = _db.Entry(SelectedSong)
                    .Collection(s => s.Albums)
                    .Query()
                    .ToList();

                var selectedAlbumsAfterChanges = SelectedSong.Albums.ToList();

                if (!selectedAlbumsBeforeChanges.SequenceEqual(selectedAlbumsAfterChanges))
                    changedProperties.Add("Albums");
            }

            // Toon een bericht met de gewijzigde eigenschappen
            if (changedProperties.Any())
            {
                string changedPropertiesString = string.Join(", ", changedProperties);
                string message = $"The following properties have been changed: {changedPropertiesString}";
                System.Windows.MessageBox.Show(message, "Changes");
            }
            else
            {
                System.Windows.MessageBox.Show("No changes have been detected.", "Changes");
            }
        }
        private void AddSong(object parameter)
        {
            ((MainWindow)Application.Current.MainWindow).Song_Click(null, null);
        }
        private void RemoveSong(object parameter)
        {
            if (SelectedSong != null)
            {
                var albumsContainingSong = _db.Albums.Where(album => album.Songs.Contains(SelectedSong)).ToList();

                if (albumsContainingSong.Any())
                {
                    string albumsList = string.Join(", ", albumsContainingSong.Select(album => album.Title));

                    var result = System.Windows.MessageBox.Show($"The song '{SelectedSong.Title}' by '{SelectedSong.Artist}' is part of the following albums: {albumsList}. Do you want to remove it from these albums?", "Confirmation", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var album in albumsContainingSong)
                        {
                            album.Songs.Remove(SelectedSong);
                        }
                        _db.SaveChanges();
                        Songs.Remove(SelectedSong);
                        _db.SaveChanges();
                        System.Windows.MessageBox.Show($"The song '{SelectedSong.Title}' by '{SelectedSong.Artist}' has been removed successfully!", "Success");
                    }
                }
                else
                {
                    Songs.Remove(SelectedSong);
                    _db.SaveChanges();
                    System.Windows.MessageBox.Show($"The song '{SelectedSong.Title}' by '{SelectedSong.Artist}' has been removed successfully!", "Success");
                }
            }
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
        }
    }
}
