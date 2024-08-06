using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MentoringProject.Services
{
    public class YouTubeService
    {
        private readonly HttpClient _httpClient;
        private const string apiKey = "YOUR_API_KEY";
        private const string baseUrl = "https://www.googleapis.com/youtube/v3/";

        public YouTubeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<YouTubeSearchResponse> SearchVideosAsync(string query)
        {
            var url = $"{baseUrl}search?part=snippet&q={query}&key={apiKey}";
            return await _httpClient.GetFromJsonAsync<YouTubeSearchResponse>(url);
        }
    }

    public class YouTubeSearchResponse
    {
        public YouTubeVideo[] Items { get; set; }
    }

    public class YouTubeVideo
    {
        public YouTubeVideoSnippet Snippet { get; set; }
        public YouTubeVideoId Id { get; set; }
    }

    public class YouTubeVideoSnippet
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public YouTubeThumbnail Thumbnails { get; set; }
    }

    public class YouTubeThumbnail
    {
        public YouTubeThumbnailDetails Default { get; set; }
    }

    public class YouTubeThumbnailDetails
    {
        public string Url { get; set; }
    }

    public class YouTubeVideoId
    {
        public string VideoId { get; set; }
    }
}
