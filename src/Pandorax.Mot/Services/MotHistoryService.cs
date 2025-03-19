using Pandorax.Mot.Core;
using Pandorax.Mot.Models;
using Pandorax.Mot.Utilities;

namespace Pandorax.Mot.Services;

public class MotHistoryService(MotHistoryHttpClient httpClient) : IMotHistoryService
{
    private readonly MotHistoryHttpClient _httpClient = httpClient;

    public async Task<MotHistoryResponse<Vehicle>> GetMotTestsByRegistrationAsync(string registration)
    {
        return await _httpClient.GetAsync<Vehicle>(ApiRoutes.MotHistory.MotHistoryByRegistration(registration));
    }
}
