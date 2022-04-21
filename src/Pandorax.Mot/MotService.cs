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
        using HttpResponseMessage response = await _client.GetAsync($"/trade/vehicles/mot-tests?page={page}");

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return new List<Vehicle>();
        }

        _ = response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        List<Vehicle>? vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json);

        return vehicles ?? new List<Vehicle>();
    }

    /// <inheritdoc />
    public async Task<IList<Vehicle>> GetMotsByDateAsync(DateTime date, int page)
    {
        using HttpResponseMessage response = await _client.GetAsync($"/trade/vehicles/mot-tests?date={date:yyyyMMdd}&page={page}");

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return new List<Vehicle>();
        }

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

        using HttpResponseMessage response = await _client.GetAsync($"/trade/vehicles/mot-tests?registration={registration}");

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

        _ = response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        // The api returns an array of one vehicle for registration requests
        List<Vehicle>? vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json);

        return vehicles?.FirstOrDefault();
    }

    /// <inheritdoc />
    public async Task<Vehicle?> GetMotsByVehicleIdAsync(string vehicleId)
    {
        if (vehicleId is null)
        {
            throw new ArgumentNullException(nameof(vehicleId));
        }

        using HttpResponseMessage response = await _client.GetAsync($"/trade/vehicles/mot-tests?vehicleId={vehicleId}");

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

        _ = response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        // The api returns an array of one vehicle for id requests
        List<Vehicle>? vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json);

        return vehicles?.FirstOrDefault();
    }
}
