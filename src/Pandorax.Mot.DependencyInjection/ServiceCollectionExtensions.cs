using Microsoft.Extensions.DependencyInjection;

namespace Pandorax.Mot.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMot(this IServiceCollection services, string apiKey)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(apiKey);

        services.AddScoped<IMotService, MotService>(provider => new MotService(apiKey));

        return services;
    }
}
