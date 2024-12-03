using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCoreAdvancedC_.Shared
{
    public static class Extensions
    {
        public static IQueryable<TSource> Paginate<TSource>(this IQueryable<TSource> sources, int pageNo, int pageSize)
        {
            return sources.Skip((pageNo-1)*pageSize).Take(pageSize);
        } 
    }
}
