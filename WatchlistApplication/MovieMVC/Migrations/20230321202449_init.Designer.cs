﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieMVC.Models;

#nullable disable

namespace MovieMVC.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20230321202449_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieMVC.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Science Fiction",
                            Description = "Science fiction (or sci-fi) is a film genre that uses speculative, fictional science-based depictions of phenomena that are not fully accepted by mainstream science, such as extraterrestrial lifeforms, spacecraft, robots, cyborgs, dinosaurs, mutants, interstellar travel, time travel, or other technologies."
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Comedy",
                            Description = "A favorite genre of film audiences young and old since the very beginning of cinema, the comedy genre has been a fun-loving, sophisticated, and innovative genre that’s delighted viewers. Some of the biggest names in the history of filmmaking include comedy genre pioneers—like Buster Keaton, Charlie Chaplin, and Lucille Ball—who made successful careers out of finding new and unique ways to make audiences laugh."
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Action",
                            Description = "One of the earliest film genres, the action genre, has close ties to classic strife and struggle narratives that you find across all manner of art and literature. With some of the earliest examples dating back to everything from historical war epics to some basic portrayals of dastardly train robberies, action films have been popular with cinema audiences since the very beginning."
                        });
                });

            modelBuilder.Entity("MovieMVC.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MovieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            About = "Set in a dystopian future where humanity is struggling to survive, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for mankind.",
                            CategoryId = 1,
                            MovieName = "Interstellar",
                            ReleaseDate = new DateTime(2014, 11, 7, 19, 32, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MovieId = 2,
                            About = "Bank clerk Stanley Ipkiss is transformed into a manic superhero when he wears a mysterious mask.",
                            CategoryId = 2,
                            MovieName = "The Mask",
                            ReleaseDate = new DateTime(1994, 6, 10, 18, 24, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MovieId = 3,
                            About = "With the help of a German bounty-hunter, a freed slave sets out to rescue his wife from a brutal plantation owner in Mississippi.",
                            CategoryId = 3,
                            MovieName = "Django Unchained",
                            ReleaseDate = new DateTime(2012, 2, 19, 23, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MovieMVC.Models.Movie", b =>
                {
                    b.HasOne("MovieMVC.Models.Category", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MovieMVC.Models.Category", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}