namespace MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    internal readonly IBlogRepository _blogRepository;

    public BlogController(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    #region GetBlogListAsync

    [HttpGet("list")]
    public async Task<IActionResult> GetBlogListAsync(int pageNo, int pageSize,CancellationToken cs)
    {
        var lst = await _blogRepository.GetBlogListAsync(pageNo, pageSize, cs);
        return Ok(lst);
    }

    #endregion

    #region GetBlogListAsyncV1

    [HttpGet("list-v1")]
    public async Task<IActionResult> GetBlogListAsyncV1(int pageNo, int pageSize, CancellationToken cs)
    {
        var lst = await _blogRepository.GetBlogListAsyncV1(pageNo, pageSize, cs);
        return Ok(lst);
    }

    #endregion

    #region CreateBlogAsync

    [HttpPost]
    public async Task<IActionResult> CreateBlogAsync([FromBody]BlogResponseModel responseModel,CancellationToken cs)
    {
        var item = await _blogRepository.CreateBlogAsync(responseModel, cs);
        return Ok(item);
    }

    #endregion

}
