using System.Text.Json.Serialization;

namespace Pandorax.Mot.Models;

/// <summary>
/// Defects found during the MOT or annual test.
/// </summary>
public class Defect
{
    /// <summary>
    /// Gets or Sets Type.
    /// </summary>
    [JsonPropertyName("type")]
    public DefectType? Type { get; set; }

    /// <summary>
    /// Description of the defect.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Whether the defect is dangerous.
    /// </summary>
    [JsonPropertyName("dangerous")]
    public bool? Dangerous { get; set; }
}
