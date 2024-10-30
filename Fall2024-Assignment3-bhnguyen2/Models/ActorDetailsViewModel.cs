namespace Fall2024_Assignment3_bhnguyen2.Models
{
    public class ActorDetailsViewModel
    {
        public Actor Actor { get; set; }
        public List<string> Movies { get; set; }
        public List<Tweet> Tweets { get; set; }
        public double SentimentAverage {  get; set; }
    }
}
