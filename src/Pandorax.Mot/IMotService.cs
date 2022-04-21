using Pandorax.Mot.Models;

namespace Pandorax.Mot;

/// <summary>
/// Defines a service for interacting with the DVSA MOT History API.
/// </summary>
public interface IMotService
{
    /// <summary>
    /// Gets all the MOT tests for a single vehicle.
    /// </summary>
    /// <param name="registration">The registration number of the vehicle.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. The result of the <see cref="Task{TResult}"/>
    /// is a <see cref="Vehicle"/> if the record exists, or null if the vehicle cannot be found.
    /// </returns>
    Task<Vehicle?> GetMotsByRegistrationAsync(string registration);

    /// <summary>
    /// Gets all the MOT tests for a given page.
    /// </summary>
    /// <param name="page">The page of mots to get. <paramref name="page"/> starts at 0 and end at around 50000 when no more results are returned.</param>
    /// <returns>A List of vehicles on the page.</returns>
    Task<IList<Vehicle>> GetMotsByPageAsync(int page);

    /// <summary>
    /// Gets MOT tests on a specific date.
    /// </summary>
    /// <param name="date">The date at which to start the page.</param>
    /// <param name="page">The page of mots to get.</param>
    /// <returns>A list of vehicles matching the given date and page.</returns>
    Task<IList<Vehicle>> GetMotsByDateAsync(DateTime date, int page);

    /// <summary>
    /// Gets the MOTs for a vehicle by the vehicle id.
    /// </summary>
    /// <param name="vehicleId">The id of the vehicle.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. The result of the <see cref="Task{TResult}"/>
    /// is a <see cref="Vehicle"/> if the record exists, or null if the vehicle cannot be found.
    /// </returns>
    Task<Vehicle?> GetMotsByVehicleIdAsync(string vehicleId);
}
