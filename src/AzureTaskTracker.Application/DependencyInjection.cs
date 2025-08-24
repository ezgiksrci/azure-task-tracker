using Microsoft.Extensions.DependencyInjection;

namespace AzureTaskTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services here
        return services;
    }
}
