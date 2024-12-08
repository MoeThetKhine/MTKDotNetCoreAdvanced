namespace MTKDotNetCoreAdvancedC_.UnitOfWork.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext _context;
        public IBlogRepository BlogRepository { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            BlogRepository ??= new BlogRepository(context);
        }
    }
}
