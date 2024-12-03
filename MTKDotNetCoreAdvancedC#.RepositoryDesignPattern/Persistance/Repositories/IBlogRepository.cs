using MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Models;
using MTKDotNetCoreAdvancedC_.Utils;

namespace MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Persistance.Repositories
{
    public interface IBlogRepository
    {
        Task<Result<List<BlogModel>>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs);
    }
}
