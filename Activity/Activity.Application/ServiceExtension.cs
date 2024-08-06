using System.Reflection;

namespace Activity.Application;

public static class ServiceExtension
{
    public static IServiceCollection AddApplicationServices
        (this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
           // TO ADD
           // config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        return services;
    }
}

