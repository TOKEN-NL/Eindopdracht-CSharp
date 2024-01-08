using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace WPF_MVVM_KB_2024.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configureer hier je databaseverbinding, bijvoorbeeld met SQL Server
            optionsBuilder.UseSqlServer("\"Server=(localdb)\\mssqllocaldb;Database=MusicStreamingDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                        .HasMany(h => h.Songs);
            // Voeg hier eventuele aanvullende configuratie toe voor je entiteiten

           
        }
    }
}
