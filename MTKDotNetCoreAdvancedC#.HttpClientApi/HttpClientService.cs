using MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Models;

namespace MTKDotNetCoreAdvancedC_.HttpClientApi
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        public async Task<BlogModel> GetBlogAsync()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BlogModel>();

            //if(response.IsSuccessStatusCode)
            //{
            //    string jsonStr = await response.Content.ReadAsStringAsync();
            //    return jsonStr
            //}
        }
    }
}
