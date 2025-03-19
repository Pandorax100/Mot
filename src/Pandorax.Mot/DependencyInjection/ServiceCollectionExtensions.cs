using Microsoft.Extensions.DependencyInjection;
using Pandorax.Mot.Authorization;
using Pandorax.Mot.Services;

namespace Pandorax.Mot.DependencyInjection;

/// <summary>
/// Provides extension methods for setting up MOT api related services in
/// an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers an <see cref="IMotHistoryService"/> in the <see cref="IServiceCollection"/>.
    /// Use this method when using dependency injection in your application, such as with
    /// ASP.NET Core.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static MotHistoryApplicationBuilder AddMotHistoryApi(this IServiceCollection services)
    {
        services.AddHttpClient<MotHistoryHttpClient>()
            .AddHttpMessageHandler<OAuthDelegatingHandler>();

        services.AddHttpClient<TokenService>();

        services.AddScoped<OAuthDelegatingHandler>();

        services.AddMemoryCache();

        services.AddScoped<IMotHistoryService, MotHistoryService>();

        return new MotHistoryApplicationBuilder(services);
    }
}
