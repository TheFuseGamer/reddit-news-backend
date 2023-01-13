using Newtonsoft.Json;

namespace RedditNews.Models
{
    public class RedditResponse
    {
        [JsonProperty("data")]
        public RedditResponseData Data { get; set; }
    }

    public class RedditResponseData
    {
        [JsonProperty("children")]
        public IEnumerable<RedditResponseDataChild> Children { get; set; }
    }

    public class RedditResponseDataChild
    {
        [JsonProperty("data")]
        public RedditPost Data { get; set; }
    }

    public class RedditPost
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("created_utc")]
        public long CreatedUtc { get; set; }

        [JsonProperty("num_comments")]
        public int NumComments { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
