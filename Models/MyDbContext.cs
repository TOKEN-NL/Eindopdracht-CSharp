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
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MusicStreamingDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .HasMany(h => h.Songs);
            modelBuilder.Entity<Song>()
                .HasMany(h => h.Albums);



            modelBuilder.Entity<Song>()
                .HasData(
                new
                {
                    Id = 1,
                    Title = "testname",
                    Genre = "Rock",
                    Artist = "Hello",
                    DurationInSeconds = 234,
                    ReleaseDate = new DateTime(2007, 4, 1)
                });
            modelBuilder.Entity<Album>()
                .HasData(
                new
                {
                    Id = 1,
                    Title = "testingg",
                    ReleaseYear = 1997,
                    CoverImage = "image"

                });
        }
    }
}
