using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetApp10.Pages
{
    public class PingModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public PingModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public string PingResult { get; set; }

        public async Task OnPostPingApi()
        {
            // Call your Ping API
            var response = await _httpClient.GetStringAsync("http://localhost:5000/api/ping");
            PingResult = response;
        }
    }
}
