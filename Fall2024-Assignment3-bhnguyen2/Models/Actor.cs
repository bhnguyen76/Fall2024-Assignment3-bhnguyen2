using System.ComponentModel.DataAnnotations;

namespace Fall2024_Assignment3_bhnguyen2.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string? IMDb { get; set; }
        public byte[]? Photo { get; set; }
    }
}
