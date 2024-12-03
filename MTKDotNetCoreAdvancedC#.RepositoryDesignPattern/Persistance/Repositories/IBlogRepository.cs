namespace MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Persistance.Repositories;

public interface IBlogRepository
{
    Task<Result<List<BlogModel>>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs);
    Task<Result<List<BlogModel>>> GetBlogListAsyncV1(int pageNo, int pageSize, CancellationToken cs);
    Task<Result<BlogResponseModel>> CreateBlogAsync(BlogResponseModel responseModel,CancellationToken cs);
    Task<Result<BlogModel>> UpdateBlogAsync(int blogId, BlogModel blog, CancellationToken cs);



}
