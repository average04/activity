namespace Activity.Infrastructure;
public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, string connectionString)
    {
        // Add services to the container.
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString));
        });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}