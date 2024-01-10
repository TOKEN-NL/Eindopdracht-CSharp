using Microsoft.EntityFrameworkCore;
using System;

namespace Eindopdracht.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP_KB;Initial Catalog=MusicStreamingDB;User ID=Webapp;Password=School123;Integrated Security=True;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .HasMany(h => h.Songs);
            modelBuilder.Entity<Song>()
                .HasMany(h => h.Albums);



            modelBuilder.Entity<Song>()
                .HasData(
                new Song
                {
                    Id = 1,
                    Title = "Bohemian Rhapsody",
                    Genre = "Rock",
                    Artist = "Queen",
                    DurationInSeconds = 354,
                    ReleaseDate = new DateTime(1975, 10, 31)
                },
                new Song
                {
                    Id = 2,
                    Title = "Shape of You",
                    Genre = "Pop",
                    Artist = "Ed Sheeran",
                    DurationInSeconds = 233,
                    ReleaseDate = new DateTime(2017, 1, 6)
                },
                new Song
                {
                    Id = 3,
                    Title = "Billie Jean",
                    Genre = "Pop",
                    Artist = "Michael Jackson",
                    DurationInSeconds = 294,
                    ReleaseDate = new DateTime(1983, 1, 2)
                },
                new Song
                {
                    Id = 4,
                    Title = "Imagine",
                    Genre = "Soft rock",
                    Artist = "John Lennon",
                    DurationInSeconds = 185,
                    ReleaseDate = new DateTime(1971, 10, 11)
                },
                new Song
                {
                    Id = 5,
                    Title = "Smells Like Teen Spirit",
                    Genre = "Grunge",
                    Artist = "Nirvana",
                    DurationInSeconds = 302,
                    ReleaseDate = new DateTime(1991, 9, 10)
                },
                new Song
                {
                    Id = 6,
                    Title = "Boys Don't Cry",
                    Genre = "Post-punk",
                    Artist = "The Cure",
                    DurationInSeconds = 174,
                    ReleaseDate = new DateTime(1979, 6, 15)
                },
                new Song
                {
                    Id = 7,
                    Title = "Wonderwall",
                    Genre = "Britpop",
                    Artist = "Oasis",
                    DurationInSeconds = 258,
                    ReleaseDate = new DateTime(1995, 10, 30)
                },
                new Song
                {
                    Id = 8,
                    Title = "Hallelujah",
                    Genre = "Folk",
                    Artist = "Leonard Cohen",
                    DurationInSeconds = 272,
                    ReleaseDate = new DateTime(1984, 1, 1)
                },
                new Song
                {
                    Id = 9,
                    Title = "Hey Jude",
                    Genre = "Pop",
                    Artist = "The Beatles",
                    DurationInSeconds = 431,
                    ReleaseDate = new DateTime(1968, 8, 26)
                });
            modelBuilder.Entity<Album>()
                .HasData(
                new Album
                {
                    Id = 1,
                    Title = "A Night at the Opera",
                    ReleaseYear = 1975,
                    CoverImage = "https://link-naar-coverfoto/queen-anato.jpg"
                },
                new Album
                {
                    Id = 2,
                    Title = "÷ (Divide)",
                    ReleaseYear = 2017,
                    CoverImage = "https://link-naar-coverfoto/ed-sheeran-divide.jpg"
                },
                new Album
                {
                    Id = 3,
                    Title = "Thriller",
                    ReleaseYear = 1982,
                    CoverImage = "https://link-naar-coverfoto/michael-jackson-thriller.jpg"
                },
                new Album
                {
                    Id = 4,
                    Title = "Imagine",
                    ReleaseYear = 1971,
                    CoverImage = "https://link-naar-coverfoto/john-lennon-imagine.jpg"
                },
                new Album
                {
                    Id = 5,
                    Title = "Nevermind",
                    ReleaseYear = 1991,
                    CoverImage = "https://link-naar-coverfoto/nirvana-nevermind.jpg"
                },
                new Album
                {
                    Id = 6,
                    Title = "Three Imaginary Boys",
                    ReleaseYear = 1979,
                    CoverImage = "https://link-naar-coverfoto/the-cure-three-imaginary-boys.jpg"
                },
                new Album
                {
                    Id = 7,
                    Title = "(What's the Story) Morning Glory?",
                    ReleaseYear = 1995,
                    CoverImage = "https://link-naar-coverfoto/oasis-morning-glory.jpg"
                },
                new Album
                {
                    Id = 8,
                    Title = "Various Positions",
                    ReleaseYear = 1984,
                    CoverImage = "https://link-naar-coverfoto/leonard-cohen-various-positions.jpg"
                },
                new Album
                {
                    Id = 9,
                    Title = "The Beatles (White Album)",
                    ReleaseYear = 1968,
                    CoverImage = "https://link-naar-coverfoto/the-beatles-white-album.jpg"
                });
        }
    }
}
