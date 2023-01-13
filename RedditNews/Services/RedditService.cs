using Newtonsoft.Json;
using RedditNews.Models;

namespace RedditNews.Services
{
    public class RedditService : IRedditService
    {
        public IEnumerable<RedditPost> GetRedditPosts(string subreddit, int n)
        {
            // Use HTTPClient to make the request
            using (var client = new HttpClient())
            {
                // Get the response from the API
                var response = client.GetAsync($"https://www.reddit.com/r/{subreddit}/top/.json?limit={n}").Result;

                // If the response is successful, parse the JSON
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var redditResponse = JsonConvert.DeserializeObject<RedditResponse>(json);
                    if (redditResponse == null)
                    {
                        return Enumerable.Empty<RedditPost>();
                    }
                    return redditResponse.Data.Children.Select(x => x.Data);
                }
                else
                {
                    return Enumerable.Empty<RedditPost>();
                }
            }
        }
    }
}