using System.Net.Http.Headers;

namespace Pandorax.Mot.Authorization;

internal sealed class OAuthDelegatingHandler(TokenService tokenService) : DelegatingHandler
{
    private readonly TokenService _tokenService = tokenService;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string? token = await _tokenService.GetAccessTokenAsync();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }
}
