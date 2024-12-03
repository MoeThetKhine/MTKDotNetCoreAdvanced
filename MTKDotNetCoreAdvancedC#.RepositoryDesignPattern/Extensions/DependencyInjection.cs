﻿using Microsoft.EntityFrameworkCore;
using MTKDotNetCoreAdvancedC_.Database.Models;
using MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Persistance.Repositories;

namespace MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Extensions
{
    public static class DependencyInjection
    {

        #region AddDependencies

        public static IServiceCollection AddDependencies(this IServiceCollection services,WebApplicationBuilder builder) 
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<IBlogRepository,BlogRepository>();
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            return services;
        }

        #endregion
    }
}
