using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pandorax.Mot.Options;

namespace Pandorax.Mot.DependencyInjection;

public class MotHistoryApplicationBuilder(IServiceCollection services)
{
    private readonly IServiceCollection _services = services;

    public MotHistoryApplicationBuilder ConfigureMotHistoryOptions(Action<MotHistoryOptions> options)
    {
        _services.Configure(options);

        return this;
    }

    public MotHistoryApplicationBuilder ConfigureMotHistoryOptions(IConfiguration configurationSection)
    {
        _services.Configure<MotHistoryOptions>(configurationSection);

        return this;
    }
}
