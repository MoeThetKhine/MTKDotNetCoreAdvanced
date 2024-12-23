
namespace MTKDotNetCoreAdvancedC_.RestClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            RestClientExample restClientExample = new();
            var lst = await restClientExample.GetAsync<List<BlogModel>>(
                "https://localhost:7281",
                $"/api/BlogEndpoint?pageNo={1}&pageSize={10}"
            );
            foreach (var item in lst!)
            {
                Console.WriteLine($"BlogId: {item.BlogId}");
                Console.WriteLine($"Blog Title: {item.BlogTitle}");
                Console.WriteLine($"Blog Author: {item.BlogAuthor}");
                Console.WriteLine($"Blog Content: {item.BlogContent}");
                Console.WriteLine("---------------------------------");
            }
        }
    }

    #region RestClientExample

    public class RestClientExample
    {
        public async Task<T> GetAsync<T>(string url, string endpoint)
        {
            RestSharp.RestClient client = new(url);
            RestRequest request = new(endpoint);
            var lst = await client.GetAsync<T>(request);

            return lst!;
        }
    }

    #endregion
}
