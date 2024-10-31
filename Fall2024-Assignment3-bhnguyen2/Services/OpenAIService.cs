using Azure.AI.OpenAI; 
using OpenAI.Chat;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2024_Assignment3_bhnguyen2.Services
{
    public class OpenAIService
    {
        private readonly AzureOpenAIClient client;
        private readonly ChatClient chatClient;

        public OpenAIService(string azureApiKey, string endpoint)
        {
            client = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(azureApiKey));
            chatClient = client.GetChatClient("gpt-35-turbo");
        }

        public async Task<List<string>> GenerateActorListAsync(string title)
        {
            ChatCompletion completion = await chatClient.CompleteChatAsync(new UserChatMessage($"List the 5 main actors from the movie '{title}' and do not number them."));

            var actorList = completion.Content[0].Text;

            return actorList?
                .Split(new[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToList() ?? new List<string>();
        }

        public async Task<List<string>> GenerateReviewsAsync(string movieTitle)
        {
            ChatCompletion completion = await chatClient.CompleteChatAsync(new UserChatMessage($"Write 10 reviews for the movie '{movieTitle}' and do not number them."));

            var reviewsList = completion.Content[0].Text;

            return reviewsList?
                .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(r => r.Trim())
                .ToList() ?? new List<string>();
        }
        public async Task<List<string>> GenerateMovieListAsync(string name)
        {
            ChatCompletion completion = await chatClient.CompleteChatAsync(new UserChatMessage($"List 5 of the most popular movies that star actor {name} and do not number them."));

            var movieList = completion.Content[0].Text;

            return movieList?
                .Split(new[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToList() ?? new List<string>();
        }

        public async Task<List<string>> GenerateTweetsAsync(string name)
        {
            ChatCompletion completion = await chatClient.CompleteChatAsync(new UserChatMessage($"Write 10 tweets about actor {name} and do not number them."));

            var reviewsList = completion.Content[0].Text;

            return reviewsList?
                .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(r => r.Trim())
                .ToList() ?? new List<string>();
        }
    }
}

