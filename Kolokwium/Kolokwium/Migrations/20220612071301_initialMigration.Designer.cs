﻿// <auto-generated />
using System;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kolokwium.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20220612071301_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kolokwium.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Hity na czasie",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(1985, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabel");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "Rock"
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.Musican_Track", b =>
                {
                    b.Property<int>("IdMusican")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusican", "IdTrack");

                    b.HasIndex("IdTrack");

                    b.ToTable("Musican_Track");

                    b.HasData(
                        new
                        {
                            IdMusican = 1,
                            IdTrack = 1
                        },
                        new
                        {
                            IdMusican = 2,
                            IdTrack = 2
                        },
                        new
                        {
                            IdMusican = 3,
                            IdTrack = 3
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NickName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musician");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Andrzej",
                            LastName = "Gitarzysta",
                            NickName = "Shreder"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "Maria",
                            LastName = "Nowak",
                            NickName = "MagicVoice"
                        },
                        new
                        {
                            IdMusician = 3,
                            FirstName = "Jan",
                            LastName = "Zielinski",
                            NickName = "Bezrobotny"
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdAlbum");

                    b.ToTable("Track");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 3.5f,
                            IdAlbum = 1,
                            TackName = "Intro"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 4.5f,
                            IdAlbum = 1,
                            TackName = "Piosenka końcowa"
                        },
                        new
                        {
                            IdTrack = 3,
                            Duration = 16.5f,
                            TackName = "Jam session"
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.Album", b =>
                {
                    b.HasOne("Kolokwium.Models.MusicLabel", "MusicLabel")
                        .WithMany("Albums")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("Kolokwium.Models.Musican_Track", b =>
                {
                    b.HasOne("Kolokwium.Models.Musician", "Musician")
                        .WithMany("Musican_Tracks")
                        .HasForeignKey("IdMusican")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Kolokwium.Models.Track", b =>
                {
                    b.HasOne("Kolokwium.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdAlbum");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Kolokwium.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Kolokwium.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("Kolokwium.Models.Musician", b =>
                {
                    b.Navigation("Musican_Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
