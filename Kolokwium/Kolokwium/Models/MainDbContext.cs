using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MainDbContext()
        {
        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Musican_Track> Musican_Track { get; set; }
        public DbSet<Musician> Musician { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Musician>(e =>
            {
                e.HasData(new Musician()
                {
                    IdMusician = 1,
                    FirstName = "Andrzej",
                    LastName = "Gitarzysta",
                    NickName = "Shreder"
                });
                e.HasData(new Musician()
                {
                    IdMusician = 2,
                    FirstName = "Maria",
                    LastName = "Nowak",
                    NickName = "MagicVoice"
                });
                e.HasData(new Musician()
                {
                    IdMusician = 3,
                    FirstName = "Jan",
                    LastName = "Zielinski",
                    NickName = "Bezrobotny"
                });
            });
            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasData(new MusicLabel()
                {
                    IdMusicLabel = 1,
                    Name = "Rock"
                });
            });
            modelBuilder.Entity<Album>(e =>
            {
                e.HasData(new Album()
                {
                    IdAlbum = 1,
                    IdMusicLabel = 1,
                    AlbumName = "Hity na czasie",
                    PublishDate = new DateTime(1985, 11, 26)
                });
            });
            modelBuilder.Entity<Track>(e =>
            {
                e.HasData(new Track()
                {
                    IdTrack = 1,
                    IdAlbum = 1,
                    Duration = 3.5f,
                    TackName = "Intro"
                });
                e.HasData(new Track()
                {
                    IdTrack = 2,
                    IdAlbum = 1,
                    Duration = 4.5f,
                    TackName = "Piosenka końcowa"
                });
                e.HasData(new Track()
                {
                    IdTrack = 3,
                    IdAlbum = null,
                    Duration = 16.5f,
                    TackName = "Jam session"
                });
            });
            modelBuilder.Entity<Musican_Track>(e =>
            {
                e.HasKey(e => new { e.IdMusican, e.IdTrack });
                e.HasData(new Musican_Track()
                {
                    IdTrack = 1,
                    IdMusican = 1
                });
                e.HasData(new Musican_Track()
                {
                    IdTrack = 2,
                    IdMusican = 2
                });
                e.HasData(new Musican_Track()
                {
                    IdTrack = 3,
                    IdMusican = 3
                });
            });
       }
    }
}
