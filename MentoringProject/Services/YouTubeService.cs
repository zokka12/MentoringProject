using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MentoringProject.Services
{
    public class YouTubeService
    {
        private readonly HttpClient _httpClient;
        private const string apiKey = "";
        private const string baseUrl = "https://www.googleapis.com/youtube/v3/";
        private readonly ILogger<YouTubeService> _logger;

        public YouTubeService(HttpClient httpClient, ILogger<YouTubeService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<YouTubeSearchResponse?> SearchVideosAsync(string? query)
        {
            _logger.LogInformation("The search has started.");

            var q = query ?? ".NET";
            var url = $"{baseUrl}search?part=snippet&q={q}&key={apiKey}";

            _logger.LogInformation("Requested URL: {Url}", url);  // Use a static string template with a placeholder.

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
