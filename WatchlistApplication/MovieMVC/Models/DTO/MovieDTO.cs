namespace MovieMVC.Models.DTO
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string About { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CategoryName { get; set; }
    }
}
