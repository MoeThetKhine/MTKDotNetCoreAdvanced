using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MTKDotNetCoreAdvancedC_.HttpClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientController : ControllerBase
    {
        private readonly HttpClientService _httpClientService;

        public HttpClientController(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlog()
        {
            var blog = await _httpClientService.GetBlogAsync();
            return Ok(blog);
        }
    }
}
