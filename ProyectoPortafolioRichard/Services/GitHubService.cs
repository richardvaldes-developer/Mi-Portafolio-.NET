using System.Text.Json;

namespace ProyectoPortafolioRichard.Services
{
    public class GitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GitHubRepo>> GetReposAsync(string username)
        {
            var url = $"https://api.github.com/users/{username}/repos";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent", "PortafolioApp"); // GitHub requiere este encabezado.

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var repos = JsonSerializer.Deserialize<List<GitHubRepo>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return repos ?? new List<GitHubRepo>();
            }

            return new List<GitHubRepo>();
        }
    }

    public class GitHubRepo
    {
        public string Name { get; set; }
        public string HtmlUrl { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
    }
}

