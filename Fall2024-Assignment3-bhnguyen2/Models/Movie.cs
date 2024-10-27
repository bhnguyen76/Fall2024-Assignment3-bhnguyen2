namespace Fall2024_Assignment3_bhnguyen2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IMBD { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public byte[]? Photo { get; set; }
    }
}
