using RedditNews.Models;

namespace RedditNews.Services
{
    public interface IRedditService
    {
        IEnumerable<RedditPost> GetRedditPosts(string subreddit, int n);
    }
}
