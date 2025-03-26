using Duende.IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Pandorax.Mot.Options;

namespace Pandorax.Mot.Authorization;

internal sealed class TokenService(IOptions<MotHistoryOptions> options, HttpClient httpClient, IMemoryCache memoryCache)
{
    private const string MemoryCacheKey = "MotHistoryApiAccessToken";
    private readonly MotHistoryOptions _options = options.Value;
    private readonly HttpClient _httpClient = httpClient;

    private readonly IMemoryCache _memoryCache = memoryCache;

    public async Task<string?> GetAccessTokenAsync()
    {
        if (_memoryCache.TryGetValue(MemoryCacheKey, out string? cachedToken))
        {
            return cachedToken;
        }

        // Otherwise, request a new token
        var tokenRequest = new ClientCredentialsTokenRequest
        {
            Address = _options.TokenUrl,
            ClientId = _options.ClientId,
            ClientSecret = _options.ClientSecret,
            Scope = MotHistoryConstants.DefaultScopeUrl,
        };

        TokenResponse tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(tokenRequest);

        if (tokenResponse.AccessToken is not null)
        {
            _memoryCache.Set(
                MemoryCacheKey,
                tokenResponse.AccessToken,
                DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn));
        }

        return tokenResponse.AccessToken;
    }
}
