using System.Text.Json.Serialization;
using Pandorax.Mot.Converters;

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
    [JsonConverter(typeof(CompletedDateConverter))]
    public DateTime CompletedDate { get; set; }

    /// <summary>
    /// Gets or sets the date on which the MOT expires.
    /// </summary>
    [JsonPropertyName("expiryDate")]
    [JsonConverter(typeof(DotSeparatedDateConverter))]
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// Gets or sets the MOT test number.
    /// </summary>
    [JsonPropertyName("motTestNumber")]
    public string MotTestNumber { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unit used for the odometer reading.
    /// </summary>
    [JsonPropertyName("odometerUnit")]
    public OdometerUnit? OdometerUnit { get; set; }

    /// <summary>
    /// Gets or sets the value of the odometer.
    /// </summary>
    [JsonPropertyName("odometerValue")]
    public int OdometerValue { get; set; }

    /// <summary>
    /// Gets or sets the comments supplied by the tester.
    /// </summary>
    [JsonPropertyName("rfrAndComments")]
    public IList<RfrAndComment> RfrAndComments { get; set; } = new List<RfrAndComment>();

    /// <summary>
    /// Gets or sets the result of the test, whether the vehicle passed or failed.
    /// </summary>
    [JsonPropertyName("testResult")]
    public TestResult TestResult { get; set; }
}
