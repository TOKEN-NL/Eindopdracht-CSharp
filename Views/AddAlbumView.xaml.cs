using Eindopdracht.Models;
using Eindopdracht.ViewModels;
using System.Windows.Controls;

namespace Eindopdracht.Views
{
    /// <summary>
    /// Interaction logic 
    /// /// </summary>
    public partial class AddAlbumView : UserControl
    {
        public AddAlbumView()
        {
            InitializeComponent();
            DataContext = new AddSongViewModel(new MyDbContext());

        }


    }
}
