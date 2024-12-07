using MTKDotNetCoreAdvancedC_.Database.Models;

namespace MTKDotNetCoreAdvancedC_.GenericRepositoryPattern.Persistance.Repository;

public class BlogRepository : RepositoryBase<TblBlog>, IBlogRepository
{
    public BlogRepository(AppDbContext context) : base(context)
    { 

    }
}
