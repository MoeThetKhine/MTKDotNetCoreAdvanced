namespace MTKDotNetCoreAdvancedC_.UnitOfWork.Persistance.Repositories;

public class BlogRepository : RepositoryBase<TblBlog>, IBlogRepository
{
    public BlogRepository(AppDbContext context)
        : base(context) { }
}
