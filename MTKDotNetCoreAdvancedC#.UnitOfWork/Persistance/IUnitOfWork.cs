using MTKDotNetCoreAdvancedC_.UnitOfWork.Persistance.Repositories;

namespace MTKDotNetCoreAdvancedC_.UnitOfWork.Persistance
{
    public interface IUnitOfWork
    {
        IBlogRepository BlogRepository { get; }
    }
}
