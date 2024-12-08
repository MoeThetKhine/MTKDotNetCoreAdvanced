using MTKDotNetCoreAdvancedC_.Database.Models;
using MTKDotNetCoreAdvancedC_.UnitOfWork.Persistance.Repositories;

namespace MTKDotNetCoreAdvancedC_.UnitOfWork.Persistance
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
