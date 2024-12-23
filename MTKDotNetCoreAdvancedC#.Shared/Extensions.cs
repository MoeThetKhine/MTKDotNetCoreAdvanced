namespace MTKDotNetCoreAdvancedC_.Shared;

#region Extensions

public static class Extensions
{
    public static IQueryable<TSource> Paginate<TSource>(this IQueryable<TSource> sources, int pageNo, int pageSize)
    {
        return sources.Skip((pageNo-1)*pageSize).Take(pageSize);
    } 
}

#endregion