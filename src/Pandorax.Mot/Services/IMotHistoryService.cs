using Pandorax.Mot.Core;
using Pandorax.Mot.Models;

namespace Pandorax.Mot.Services;

public interface IMotHistoryService
{
    Task<MotHistoryResponse<Vehicle>> GetMotTestsByRegistrationAsync(string registration);
}
