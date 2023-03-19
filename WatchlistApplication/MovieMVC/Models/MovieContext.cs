using Microsoft.EntityFrameworkCore;

namespace MovieMVC.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MovieCategoryDB;Trusted_Connection=true");
        }
    }
}
