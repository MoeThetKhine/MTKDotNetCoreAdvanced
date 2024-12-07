using System.Linq.Expressions;

namespace MTKDotNetCoreAdvancedC_.GenericRepositoryPattern.Persistance;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> Query(Expression<Func<T, bool>>? expression = null);
    Task AddAsync(T entity, CancellationToken cs = default);
    void Add(T entity);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cs);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    void Dispose();
    Task SaveChangesAsync(CancellationToken cs = default);
    void SaveChanges();

}
