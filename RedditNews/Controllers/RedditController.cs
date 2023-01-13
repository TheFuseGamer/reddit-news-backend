using Microsoft.AspNetCore.Mvc;
using RedditNews.Models;
using RedditNews.Services;

namespace RedditNews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedditController : ControllerBase
    {
        private readonly IRedditService _redditService;

        public RedditController(IRedditService redditService)
        {
            _redditService = redditService;
        }

        [HttpGet]
        public IActionResult Get(string subreddit, int n)
        {
            return Ok(_redditService.GetRedditPosts(subreddit, n));
        }

        [HttpPost("random")]
        public IActionResult GetRandom(string[] subreddits, int n)
        {
            var posts = new List<RedditPost>();
            foreach (var subreddit in subreddits)
            {
                posts.AddRange(_redditService.GetRedditPosts(subreddit, n));
            }
            return Ok(posts.OrderBy(x => Guid.NewGuid()).Take(n));
        }
    }
}
