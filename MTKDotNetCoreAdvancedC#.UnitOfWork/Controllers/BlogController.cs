namespace MTKDotNetCoreAdvancedC_.UnitOfWork.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    internal readonly IUnitOfWork _unitOfWork;

    public BlogController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #region GetBlogsAsync

    [HttpGet]
    public async Task<IActionResult> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        var query = _unitOfWork.BlogRepository.Query().Paginate(pageNo, pageSize);
        var lst = await query.ToListAsync(cs);

        return Ok(lst);
    }

    #endregion

    #region GetBlogByIdAsync

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogByIdAsync(int id, CancellationToken cs)
    {
        var blog = await _unitOfWork.BlogRepository
            .Query(b => b.BlogId == id)
            .FirstOrDefaultAsync(cs);
        if (blog is null)
        {
            return NotFound(new { Message = $"Blog with ID {id} not found." });
        }

        return Ok(blog);
    }

    #endregion

}
