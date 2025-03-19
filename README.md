# Mot
A C# Wrapper around the DVSA MOT History API. https://documentation.history.mot.api.gov.uk/

## Installation

To install the package, use the following command:

```sh
dotnet add package Pandorax.Mot
```

## Usage

To use the MOT History API in your application, you need to register the services in your `IServiceCollection`. You can do this in your `Startup.cs` or `Program.cs` file:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Pandorax.Mot.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMotHistoryApi()
                .ConfigureMotHistoryOptions(options =>
                {
                    options.ApiKey = "your-api-key";
                    options.ClientId = "your-client-id";
                    options.ClientSecret = "your-client-secret";
                });
    }
}
```

## Services

The main service provided by this library is `IMotHistoryService`. You can use it to fetch MOT history data:

```csharp
using Pandorax.Mot.Services;

public class MotHistoryConsumer
{
    private readonly IMotHistoryService _motHistoryService;

    public MotHistoryConsumer(IMotHistoryService motHistoryService)
    {
        _motHistoryService = motHistoryService;
    }

    public async Task GetMotHistory(string registration)
    {
        var result = await _motHistoryService.GetMotTestsByRegistrationAsync(registration);
        // Handle the result
    }
}
