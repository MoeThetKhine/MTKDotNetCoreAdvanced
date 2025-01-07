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

    #region CreateBlogAsync


    [HttpPost]
    public async Task<IActionResult> CreateBlogAsync([FromBody] BlogRequestModel newBlog, CancellationToken cs)
    {
        if(newBlog is null)
        {
            return BadRequest(new { Message = "Invalid blog data." });
        }


        var blogEntity = newBlog.Change();

        await _unitOfWork.BlogRepository.AddAsync(blogEntity, cs);
        await _unitOfWork.BlogRepository.SaveChangesAsync(cs);

        return Ok("New Blog is Created");
    }

    #endregion

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlogAsync(int id, [FromBody] BlogRequestModel updatedBlog, CancellationToken cs)
    {
        if (updatedBlog is null)
        {
            return BadRequest(new { Message = "Invalid blog data." });
        }

        var blogEntity = await _unitOfWork.BlogRepository.Query(x => x.BlogId == id).FirstOrDefaultAsync(cs);

        if (blogEntity is null)
        {
            return NotFound(new { Message = $"Blog with ID {id} not found." });
        }

        blogEntity.BlogTitle = updatedBlog.BlogTitle;
        blogEntity.BlogAuthor = updatedBlog.BlogAuthor;
        blogEntity.BlogContent = updatedBlog.BlogContent;

        _unitOfWork.BlogRepository.Update(blogEntity);
        await _unitOfWork.BlogRepository.SaveChangesAsync(cs);

        return Ok(new { Message = "Blog updated successfully.", blogEntity });
    }

}
