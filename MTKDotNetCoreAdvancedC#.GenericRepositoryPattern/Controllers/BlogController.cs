namespace MTKDotNetCoreAdvancedC_.GenericRepositoryPattern.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    public readonly IBlogRepository _blogRepository;

    public BlogController(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    #region GetBlogAsync

    [HttpGet]
    public async Task<IActionResult> GetBlogAsync(int pageNo, int pageSize,CancellationToken cs)
    {
        var query = _blogRepository.Query().Paginate(pageNo, pageSize);
        var lst = await query.ToListAsync(cs);

        return Ok(lst);
    }

    #endregion

    #region GetBlogByIdAsync

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogByIdAsync(int id, CancellationToken cs)
    {
        var blog = await _blogRepository.Query(b => b.BlogId == id).FirstOrDefaultAsync(cs);
        if (blog is null)
        {
            return NotFound();
        }
        return Ok(blog);
    }

    #endregion

}
