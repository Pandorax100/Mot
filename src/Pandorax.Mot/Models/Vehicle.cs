using System.Text.Json.Serialization;

namespace Pandorax.Mot.Models;

/// <summary>
/// Basic vehicle details with mot results.
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Gets or sets the date the vehicle was first used.
    /// </summary>
    [JsonPropertyName("firstUsedDate")]
    public string? FirstUsedDate { get; set; }

    /// <summary>
    /// Gets or sets the type of fuel the vehicle takes.
    /// </summary>
    [JsonPropertyName("fuelType")]
    public string FuelType { get; set; } = null!;

    /// <summary>
    /// Gets or sets the make of the vehicle.
    /// </summary>
    [JsonPropertyName("make")]
    public string Make { get; set; } = null!;

    /// <summary>
    /// Gets or sets the model of the vehicle.
    /// </summary>
    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    /// <summary>
    /// Gets or sets the MOT tests for this vehicle.
    /// </summary>
    [JsonPropertyName("motTests")]
    public List<MotTest> MotTests { get; set; } = new();

    /// <summary>
    /// Gets or sets the colour of this vehicle.
    /// </summary>
    [JsonPropertyName("primaryColour")]
    public string PrimaryColour { get; set; } = null!;

    /// <summary>
    /// Gets or sets the registration number of this vehicle.
    /// </summary>
    [JsonPropertyName("registration")]
    public string Registration { get; set; } = null!;
}
