namespace MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Persistance.Repositories;

public interface IBlogRepository
{
    Task<Result<List<BlogModel>>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs);
    Task<Result<List<BlogModel>>> GetBlogListAsyncV1(int pageNo, int pageSize, CancellationToken cs);

}
