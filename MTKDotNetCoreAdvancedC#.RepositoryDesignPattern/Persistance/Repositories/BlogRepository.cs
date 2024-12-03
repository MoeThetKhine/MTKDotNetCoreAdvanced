namespace MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Persistance.Repositories;

public class BlogRepository : IBlogRepository
{
    internal readonly AppDbContext _context;

    public BlogRepository(AppDbContext context)
    {
        _context = context;
    }

    #region GetBlogListAsync

    public async Task<Result<List<BlogModel>>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<List<BlogModel>> result;
        try
        {
            var query = _context.TblBlogs
                .Paginate(pageNo,pageSize);

            var lst = await query.Select(x => new BlogModel()
            {
                BlogId = x.BlogId,
                BlogTitle = x.BlogTitle,
                BlogAuthor = x.BlogAuthor,
                BlogContent = x.BlogContent,
                IsActive = true

            }).ToListAsync(cs);

            result = Result<List<BlogModel>>.Success(lst);
        }
        
        catch (Exception ex)
        {
            result = Result<List<BlogModel>>.Fail(ex);
        }
        return result;
    }

    #endregion

    #region GetBlogListAsyncV1

    public async Task<Result<List<BlogModel>>> GetBlogListAsyncV1(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<List<BlogModel>> result;
        var query = _context.TblBlogs
            .Paginate(pageNo, pageSize);
        var lst = await query.Select(x => new BlogModel()
        {
            BlogId = x.BlogId,
            BlogTitle = x.BlogTitle,
            BlogAuthor = x.BlogAuthor,
            BlogContent = x.BlogContent,
            IsActive = true

        }).ToListAsync(cs);

        result = Result<List<BlogModel>>.Success(lst);

        return result;
    }

    #endregion

    #region CreateBlogAsync

    public async Task<Result<BlogResponseModel>> CreateBlogAsync(BlogResponseModel responseModel ,CancellationToken cs)
    {
        Result<BlogResponseModel> result;
        try
        {
            var item = new TblBlog
            {
                BlogTitle = responseModel.BlogTitle,
                BlogAuthor = responseModel.BlogAuthor,
                BlogContent = responseModel.BlogContent,
                IsActive = true,
            };

            await _context.TblBlogs.AddAsync(item,cs);
            await _context.SaveChangesAsync(cs);

            result = Result<BlogResponseModel>.Success(responseModel);
        }
        catch(Exception ex)
        {
            result = Result<BlogResponseModel>.Fail(ex);
        }
        return result;
    }


    #endregion

    public async Task<Result<BlogResponseModel>> UpdateBlogAsync(int blogId, BlogResponseModel blog, CancellationToken cs)
    {
        Result<BlogResponseModel> result;

        try
        {
            var item = await _context.TblBlogs.FirstOrDefaultAsync(x=> x.BlogId == blogId,cs);

            if(item is null)
            {
                result = Result<BlogResponseModel>.Fail("No Data Found");
                return result;
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _context.TblBlogs.Update(item);
            await _context.SaveChangesAsync(cs);

            result = Result<BlogResponseModel>.Success(blog);
        }
        catch(Exception ex)
        {
            result = Result<BlogResponseModel>.Fail(ex);
        }

        return result;
    }
}
