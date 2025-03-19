using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pandorax.Mot.Core;
using Pandorax.Mot.Options;
using Pandorax.Mot.Serialization;

namespace Pandorax.Mot.Services;

public class MotHistoryHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<MotHistoryHttpClient> _logger;
    private readonly MotHistoryOptions _options;
    private readonly JsonSerializerOptions _jsonSerializerOptions = MotHistoryJsonSerializerOptions.JsonSerializerOptions;

    public MotHistoryHttpClient(HttpClient httpClient, IOptions<MotHistoryOptions> options, ILogger<MotHistoryHttpClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _options = options.Value;
        _httpClient.BaseAddress = new Uri(MotHistoryConstants.DefaultBaseApiUrl);
        _httpClient.DefaultRequestHeaders.Add("X-API-Key", _options.ApiKey);
    }

    public async Task<MotHistoryResponse<TResponse>> GetAsync<TResponse>(string url)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, url);

        using HttpResponseMessage response = await _httpClient.SendAsync(request);

        return await HandleResponse<TResponse>(response);
    }

    private async Task<MotHistoryResponse<TResponse>> HandleResponse<TResponse>(HttpResponseMessage response)
    {
        string rawJson = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            TResponse? jsonResult = JsonSerializer.Deserialize<TResponse>(rawJson, _jsonSerializerOptions);

            return new MotHistoryResponse<TResponse>(
                jsonResult,
                rawJson,
                true,
                response.StatusCode);
        }
        else
        {
            return new MotHistoryResponse<TResponse>(default, rawJson, false, response.StatusCode);
        }
    }
}
