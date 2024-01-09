using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Eindopdracht.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Eindopdracht.ViewModels;
using Eindopdracht.Views;

namespace Eindopdracht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainView();
        }
        public void MainView()
        {
            var db = ((App)Application.Current).ServiceProvider.GetService<MyDbContext>();

            var AllSongsViewModel = new AllSongsViewModel(db);

            // Maak een nieuwe instantie van de AddSongView en wijs de DataContext toe aan AddSongViewModel
            var AllSongsView = new AllSongsView();
            AllSongsView.DataContext = AllSongsViewModel;

            // Wijs de Content van de ContentControl toe aan de AddSongView
            contentControl.Content = AllSongsView;
        }
        private void Album_Click(object sender, RoutedEventArgs e)
        {
            

        }
        private void Artist_Click(object sender, RoutedEventArgs e)
        {

        }
        public void Song_Click(object sender, RoutedEventArgs e)
        {
            var db = ((App)Application.Current).ServiceProvider.GetService<MyDbContext>();

            var addSongViewModel = new AddSongViewModel(db);

            // Maak een nieuwe instantie van de AddSongView en wijs de DataContext toe aan AddSongViewModel
            var addSongView = new AddSongView();
            addSongView.DataContext = addSongViewModel;

            // Wijs de Content van de ContentControl toe aan de AddSongView
            contentControl.Content = addSongView;
         
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //typing in searchbox 
            
        }
    }
}
