using Eindopdracht.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

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
        public void MainView() { logic("AllSongs"); }
        private void Home_Click(object sender, RoutedEventArgs e) { logic("AllSongs"); }
        private void Connect_Click(object sender, RoutedEventArgs e) { logic("Connect"); }
        private void Album_Click(object sender, RoutedEventArgs e) { logic("AddAlbum"); }
        public void Song_Click(object sender, RoutedEventArgs e) { logic("AddSong"); }
        private void AlbumList_Click(object sender, RoutedEventArgs e) 
        {
            System.Windows.MessageBox.Show("This page does not exist yet :)", "Error");

            //  logic("AllAlbums"); 
        }


        public void logic(string page)
        {
            //Navigation logic function

            string viewName = $"{page}View";
            string viewModelName = $"{page}ViewModel";
            Type viewModelType = Type.GetType($"Eindopdracht.ViewModels.{viewModelName}");

            if (viewModelType != null)
            {
                var db = ((App)Application.Current).ServiceProvider.GetService<MyDbContext>();
                var viewModel = Activator.CreateInstance(viewModelType, db);

                Type viewType = Type.GetType($"Eindopdracht.Views.{viewName}");
                if (viewType != null)
                {
                    var view = Activator.CreateInstance(viewType);
                    var property = view.GetType().GetProperty("DataContext");
                    if (property != null)
                    {
                        property.SetValue(view, viewModel);
                        contentControl.Content = view;
                    }
                    else
                    {
                        // DataContext property niet gevonden in de view
                        System.Windows.MessageBox.Show("DataContext not found", "Error");

                    }
                }
                else
                {
                    // viewType niet gevonden
                    System.Windows.MessageBox.Show("ViewType not found", "Error");

                }
            }
            else
            {
                // viewModelType niet gevonden
                System.Windows.MessageBox.Show("ViewModelType not found", "Error");

            }
        }

    }
}
