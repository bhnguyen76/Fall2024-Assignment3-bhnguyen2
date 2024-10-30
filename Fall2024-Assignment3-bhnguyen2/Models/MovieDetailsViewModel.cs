using Fall2024_Assignment3_bhnguyen2.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Identity.Client;

namespace Fall2024_Assignment3_bhnguyen2.Models
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }
        public List<string> Actors { get; set; }
        public List<Review> Reviews { get; set; } 
        public double SentimentAverage { get; set; }
    }
}

