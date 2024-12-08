namespace MTKDotNetCoreAdvancedC_.UnitOfWork.Persistance
{
    public interface IUnitOfWork
    {
        IBlogRepository BlogRepository { get; }
    }
}
