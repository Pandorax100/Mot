using System.Text.Json.Serialization;

namespace Pandorax.Mot.Models;

/// <summary>
/// Represents an MOT Test.
/// </summary>
public class MotTest
{
    /// <summary>
    /// Gets or sets the date on which the test was completed.
    /// </summary>
    [JsonPropertyName("completedDate")]
    public DateTime CompletedDate { get; set; }

    /// <summary>
    /// Gets or sets the result of the test, whether the vehicle passed or failed.
    /// </summary>
    [JsonPropertyName("testResult")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TestResult TestResult { get; set; }

    /// <summary>
    /// Gets or sets the date on which the MOT expires.
    /// </summary>
    [JsonPropertyName("expiryDate")]
    public DateOnly? ExpiryDate { get; set; }

    /// <summary>
    /// Gets or sets the MOT test number.
    /// </summary>
    [JsonPropertyName("motTestNumber")]
    public string? MotTestNumber { get; set; }

    /// <summary>
    /// Gets or sets the unit used for the odometer reading.
    /// </summary>
    [JsonPropertyName("odometerUnit")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OdometerUnit? OdometerUnit { get; set; }

    /// <summary>
    /// Gets or sets the value of the odometer.
    /// </summary>
    [JsonPropertyName("odometerValue")]
    public int? OdometerValue { get; set; }

    [JsonPropertyName("odometerResultType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OdometerResultType OdometerResultType { get; set; }

    /// <summary>
    /// Name of the Authorised Test Facility (ATF) where the test was conducted.
    /// </summary>
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>
    /// Gets or sets the comments supplied by the tester.
    /// </summary>
    [JsonPropertyName("defects")]
    public IList<Defect> Defects { get; set; } = [];
}
