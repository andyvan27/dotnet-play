using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetApp10.Pages
{
    public class PingModel(IHttpClientFactory httpClientFactory) : PageModel
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

        public string PingResult { get; set; } = string.Empty;

        public async Task OnPostPingApi()
        {
            // Call your Ping API
            var response = await _httpClient.GetStringAsync("https://localhost:5001/api/ping");
            PingResult = response;
        }
    }
}
