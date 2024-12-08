namespace MTKDotNetCoreAdvancedC_.UnitOfWork.Persistance;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    internal readonly AppDbContext _context;
    internal DbSet<T> _dbSet;

    public RepositoryBase(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    #region Add

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    #endregion

    #region AddAsync

    public async Task AddAsync(T entity, CancellationToken cs = default)
    {
        await _dbSet.AddAsync(entity, cs);
    }

    #endregion

    #region AddRange

    public void AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    #endregion

    #region AddRangeAsync

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cs)
    {
        await _dbSet.AddRangeAsync(entities, cs);
    }

    #endregion

    #region Delete

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    #endregion

    #region DeleteRange

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    #endregion

    public void Dispose()
    {
        _context.Dispose();
    }

    public IQueryable<T> Query(Expression<Func<T, bool>>? expression = null)
    {
        return expression is null ? _dbSet.AsQueryable() : _dbSet.Where(expression);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken cs = default)
    {
        await _context.SaveChangesAsync(cs);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }
}
