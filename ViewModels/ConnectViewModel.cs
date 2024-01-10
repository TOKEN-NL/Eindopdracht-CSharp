using CSharpLes42;
using Eindopdracht.Models;
using System.Windows;

namespace Eindopdracht.ViewModels
{
    public class ConnectViewModel : ViewModelBase
    {
        private readonly MyDbContext _db;

        public RelayCommand SongToAlbumsCommand { get; set; }
        public RelayCommand AlbumToSongsCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }



        public ConnectViewModel(MyDbContext db)
        {
            _db = db;
            SongToAlbumsCommand = new RelayCommand(SongToAlbums);
            AlbumToSongsCommand = new RelayCommand(AlbumToSongs);
            CancelCommand = new RelayCommand(Cancel);

        }

        private void SongToAlbums(object parameter)
        {

            ((MainWindow)Application.Current.MainWindow).logic("ConnectSongToAlbum");
        }
        private void AlbumToSongs(object parameter)
        {
            System.Windows.MessageBox.Show("This function does not exist yet", "Error");

            // ((MainWindow)Application.Current.MainWindow).logic("ConnectAlbumToSong");
        }
        private void Cancel(object parameter)
        {
            ((MainWindow)Application.Current.MainWindow).MainView();
        }
    }
}
