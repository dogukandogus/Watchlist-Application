using Microsoft.EntityFrameworkCore;

namespace MovieMVC.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EFOB25G;Database=MovieCategory2DB;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryName= "Science Fiction", Description= "Science fiction (or sci-fi) is a film genre that uses speculative, fictional science-based depictions of phenomena that are not fully accepted by mainstream science, such as extraterrestrial lifeforms, spacecraft, robots, cyborgs, dinosaurs, mutants, interstellar travel, time travel, or other technologies.",CategoryId=1 },
                new Category { CategoryName= "Comedy", Description= "A favorite genre of film audiences young and old since the very beginning of cinema, the comedy genre has been a fun-loving, sophisticated, and innovative genre that’s delighted viewers. Some of the biggest names in the history of filmmaking include comedy genre pioneers—like Buster Keaton, Charlie Chaplin, and Lucille Ball—who made successful careers out of finding new and unique ways to make audiences laugh.",CategoryId=2 },
                new Category { CategoryName= "Action", Description= "One of the earliest film genres, the action genre, has close ties to classic strife and struggle narratives that you find across all manner of art and literature. With some of the earliest examples dating back to everything from historical war epics to some basic portrayals of dastardly train robberies, action films have been popular with cinema audiences since the very beginning.", CategoryId=3 }
                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie() { MovieId=1, MovieName= "Interstellar",About= "Set in a dystopian future where humanity is struggling to survive, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for mankind.",ReleaseDate= Convert.ToDateTime("2014-11-07 19:32:00"),CategoryId=1 },
                new Movie() { MovieId = 2, MovieName = "The Mask", About = "Bank clerk Stanley Ipkiss is transformed into a manic superhero when he wears a mysterious mask.", ReleaseDate = Convert.ToDateTime("1994-06-10 18:24:00.0000000"), CategoryId = 2 },
                new Movie() { MovieId = 3, MovieName = "Django Unchained", About = "With the help of a German bounty-hunter, a freed slave sets out to rescue his wife from a brutal plantation owner in Mississippi.", ReleaseDate = Convert.ToDateTime("2012-02-19 23:00:00.0000000"), CategoryId=3 }


                );


        }
    }
}
