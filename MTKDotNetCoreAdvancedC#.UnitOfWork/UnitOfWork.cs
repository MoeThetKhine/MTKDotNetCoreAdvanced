namespace MTKDotNetCoreAdvancedC_.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        internal readonly AppDbContext _context;
        public IBlogRepository BlogRepository { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            BlogRepository ??= new BlogRepository(context);
        }
    }
}
