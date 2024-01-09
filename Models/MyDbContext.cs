﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Eindopdracht.Models;
using Microsoft.EntityFrameworkCore;

namespace Eindopdracht.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configureer hier je databaseverbinding, bijvoorbeeld met SQL Server
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MusicStreamingDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .HasMany(h => h.Songs);
            modelBuilder.Entity<Song>()
                .HasMany(h => h.Albums);
            modelBuilder.Entity<Artist>()
                .HasMany(h => h.Songs);
            modelBuilder.Entity<Album>()
                .HasMany(h => h.Artists);
            modelBuilder.Entity<Song>()
                .HasMany(h => h.Artists);
            modelBuilder.Entity<Artist>()
                .HasMany(h => h.Albums);

            // Voeg hier eventuele aanvullende configuratie toe voor je entiteiten

            modelBuilder.Entity<Artist>()
                .HasData(
                new
                {
                    Id = 1,
                    ArtistName = "testname",
                    FirstName = "test",
                    LastName = "name"
                }); 
            modelBuilder.Entity<Song>()
                .HasData(
                new
                {
                    Id = 1,
                    Title = "testname",
                    Genre = "Rock",
                    DurationInSeconds = 234,
                    ReleaseDate = new DateTime(20000)
                });
        }
    }
}
