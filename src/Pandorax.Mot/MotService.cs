using System.Text.Json;
using Pandorax.Mot.Configuration;
using Pandorax.Mot.Models;

namespace Pandorax.Mot;

/// <summary>
/// The default implementation for the <see cref="IMotService"/>.
/// </summary>
public sealed class MotService : IMotService, IDisposable
{
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="MotService"/> class.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> to make requests with.</param>
    public MotService(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MotService"/> class.
    /// </summary>
    /// <param name="apiKey">Your MOT API Key.</param>
    public MotService(string apiKey)
    {
        if (apiKey is null)
        {
            throw new ArgumentNullException(nameof(apiKey));
        }

        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add(MotConstants.ApiKeyHeaderName, apiKey);
        _client.BaseAddress = new Uri(MotConstants.DefaultBaseAddress);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _client.Dispose();
    }

    /// <inheritdoc />
    public async Task<IList<Vehicle>> GetMotsByPageAsync(int page)
    {
        HttpResponseMessage response = await _client.GetAsync($"/trade/vehicles/mot-tests?page={page}");

        _ = response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        List<Vehicle>? vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json);

        return vehicles ?? new List<Vehicle>();
    }

    /// <inheritdoc />
    public async Task<IList<Vehicle>> GetMotsByDateAsync(DateTime date, int page)
    {
        HttpResponseMessage response = await _client.GetAsync($"/trade/vehicles/mot-tests?date={date:yyyyMMdd}&page={page}");

        _ = response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        List<Vehicle>? vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json);

        return vehicles ?? new List<Vehicle>();
    }

    /// <inheritdoc />
    public async Task<Vehicle?> GetMotsByRegistrationAsync(string registration)
    {
        if (registration is null)
        {
            throw new ArgumentNullException(nameof(registration));
        }

        HttpResponseMessage response = await _client.GetAsync($"/trade/vehicles/mot-tests?registration={registration}");

        _ = response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        Vehicle? vehicle = JsonSerializer.Deserialize<Vehicle>(json);

        return vehicle;
    }

    /// <inheritdoc />
    public async Task<Vehicle?> GetMotsByVehicleIdAsync(string vehicleId)
    {
        if (vehicleId is null)
        {
            throw new ArgumentNullException(nameof(vehicleId));
        }

        HttpResponseMessage response = await _client.GetAsync($"/trade/vehicles/mot-tests?vehicleId={vehicleId}");

        _ = response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        Vehicle? vehicle = JsonSerializer.Deserialize<Vehicle>(json);

        return vehicle;
    }
}
