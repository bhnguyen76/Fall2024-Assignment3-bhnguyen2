using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Fall2024_Assignment3_bhnguyen2.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? IMDb { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public byte[]? Photo { get; set; }
    }
}
