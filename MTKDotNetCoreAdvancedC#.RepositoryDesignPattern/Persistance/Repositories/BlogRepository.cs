using Microsoft.EntityFrameworkCore;
using MTKDotNetCoreAdvancedC_.Database.Models;
using MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Models;
using MTKDotNetCoreAdvancedC_.Utils;

namespace MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Persistance.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        internal readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<BlogModel>>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs)
        {
            Result<List<BlogModel>> result;
            try
            {
                var query = _context.TblBlogs.Where(x => x.IsActive == true).Skip(pageNo - 1).Take(pageSize);
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
    }
}
