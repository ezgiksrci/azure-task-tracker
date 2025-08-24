using Microsoft.Extensions.DependencyInjection;

namespace AzureTaskTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register infrastructure services here
        return services;
    }
}
