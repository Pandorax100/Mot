using System.Text.Json.Serialization;
using Pandorax.Mot.Converters;

namespace Pandorax.Mot.Models;

/// <summary>
/// The result of the test.
/// </summary>
[JsonConverter(typeof(TestResultConverter))]
public enum TestResult
{
    /// <summary>
    /// The vehicle failed the test.
    /// </summary>
    Failed,

    /// <summary>
    /// The vehicle passed the test.
    /// </summary>
    Passed,
}
