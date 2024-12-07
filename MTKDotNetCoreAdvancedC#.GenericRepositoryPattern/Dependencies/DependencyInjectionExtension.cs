namespace MTKDotNetCoreAdvancedC_.GenericRepositoryPattern.Dependencies;

public static class DependencyInjectionExtension
{

    #region DependencyInjectionExtension

    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

        services.AddScoped<IBlogRepository, BlogRepository>();

        return services;
    }

    #endregion
}
