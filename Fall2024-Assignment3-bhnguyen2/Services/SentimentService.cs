using Fall2024_Assignment3_bhnguyen2.Models;
using VaderSharp2;

namespace Fall2024_Assignment3_bhnguyen2.Services
{
    public class SentimentService
    {
        private readonly SentimentIntensityAnalyzer analyzer;

        public SentimentService()
        {
            analyzer = new SentimentIntensityAnalyzer();
        }

        public Dictionary<string, Review> AnalyzeSentimentsReviews(List<string> reviews)
        {
            var sentiments = new Dictionary<string, Review>();
            double sentimentTotal = 0;
            foreach (var review in reviews)
            {
                SentimentAnalysisResults sentiment = analyzer.PolarityScores(review);
                sentimentTotal += sentiment.Compound;

                sentiments[review] = new Review{Content = review, Sentiment = sentiment.Compound};
            }

            return sentiments;
        }

        public Dictionary<string, Tweet> AnalyzeSentimentsTweets(List<string> tweets)
        {
            var sentiments = new Dictionary<string, Tweet>();
            double sentimentTotal = 0;
            foreach (var tweet in tweets)
            {
                SentimentAnalysisResults sentiment = analyzer.PolarityScores(tweet);
                sentimentTotal += sentiment.Compound;

                sentiments[tweet] = new Tweet { Content = tweet, Sentiment = sentiment.Compound };
            }

            return sentiments;
        }
    }
}
