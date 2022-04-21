using System.Text.Json.Serialization;
using Pandorax.Mot.Converters;

namespace Pandorax.Mot.Models;

/// <summary>
/// The available units for an odometer reading.
/// </summary>
[JsonConverter(typeof(OdometerUnitConverter))]
public enum OdometerUnit
{
    /// <summary>
    /// The odometer reading is in kilometres.
    /// </summary>
    Km,

    /// <summary>
    /// The odometer reading is in miles.
    /// </summary>
    Mi,
}
