using Microsoft.Extensions.DependencyInjection;

namespace Pandorax.Mot.DependencyInjection;

/// <summary>
/// Provides extension methods for setting up MOT api related services in
/// an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers an <see cref="IMotService"/> in the <see cref="IServiceCollection"/>.
    /// Use this method when using dependency injection in your application, such as with
    /// ASP.NET Core.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="apiKey">Your MOT API key.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static IServiceCollection AddMot(this IServiceCollection services, string apiKey)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(apiKey);

        services.AddScoped<IMotService, MotService>(provider => new MotService(apiKey));

        return services;
    }
}
