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

    #region CreateBlogAsync

    [HttpPost]

    public async Task<IActionResult> CreateBlogAsync([FromBody] BlogRequestModel blog, CancellationToken cs)
    {
        if(blog is null)
        {
            return BadRequest("Blog Data is invalid.");
        }

        var blogEntity = blog.Change();
        await _blogRepository.AddAsync(blogEntity, cs);
        await _blogRepository.SaveChangesAsync(cs);

        return Ok("Created Successfully.");
    }

    #endregion

    #region UpdateBlogAsync

    [HttpPut("{id}")]   
    public async Task<IActionResult> UpdateBlogAsync(int id, [FromBody] BlogRequestModel blog, CancellationToken cs)
    {
        var existingBlog = await _blogRepository.Query(b => b.BlogId == id).FirstOrDefaultAsync(cs);
        if(existingBlog is null)
        {
            return NotFound("Blog Id is not found");
        }

        existingBlog.BlogTitle = blog.BlogTitle;
        existingBlog.BlogAuthor = blog.BlogAuthor;
        existingBlog.BlogContent = blog.BlogContent;

        _blogRepository.Update(existingBlog);
        await _blogRepository.SaveChangesAsync(cs);

        return Ok("Updated Successfully.");
    }

    #endregion

    #region DeleteBlogAsync

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlogAsync(int id, CancellationToken cs)
    {
        var blog = await _blogRepository.Query(b => b.BlogId == id).FirstOrDefaultAsync(cs);
        if(blog is null)
        {
            return NotFound("Blog Id is not found");
        }
        _blogRepository.Delete(blog);
        await _blogRepository.SaveChangesAsync(cs);

        return Ok("Deleted Successfully");
    }

    #endregion
}
