namespace MovieMVC.Models
{
    public class Category
    {
        public Category()
        {
            Movies = new List<Movie>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}
