using Blazor.SimpleGrid.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.SimpleGrid.Extensions;

/// <summary>
/// Provides extension methods to register SimpleGrid services.
/// </summary>
public static class SimpleGridServiceCollectionExtensions
{
    /// <summary>
    /// Adds SimpleGrid configuration options to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">An optional delegate to configure the global defaults.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddSimpleGrid(this IServiceCollection services, Action<SimpleGridOptions>? configure = null)
    {
        var options = new SimpleGridOptions();

        // Execute the user's configuration if provided
        configure?.Invoke(options);

        // Register as Singleton so it's available everywhere in the app
        services.AddSingleton(options);

        return services;
    }
}
