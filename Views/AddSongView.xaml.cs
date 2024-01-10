﻿using Eindopdracht.Models;
using Eindopdracht.ViewModels;
using System.Windows.Controls;

namespace Eindopdracht.Views
{
    /// <summary>
    /// Interaction logic for SongDetailsView.xaml
    /// </summary>
    public partial class AddSongView : UserControl
    {
        public AddSongView()
        {
            InitializeComponent();
            DataContext = new AddSongViewModel(new MyDbContext());

        }


    }
}
