using System.Text.Json;
using System.Text.Json.Serialization;
using Pandorax.Mot.Models;

namespace Pandorax.Mot.Converters;

internal class OdometerUnitConverter : JsonConverter<OdometerUnit>
{
    public override OdometerUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            "km" => OdometerUnit.Km,
            "mi" => OdometerUnit.Mi,
            _ => throw new ArgumentOutOfRangeException(nameof(reader), $"The value {value} cannot be converted to OdometerUnit"),
        };
    }

    public override void Write(Utf8JsonWriter writer, OdometerUnit value, JsonSerializerOptions options)
    {
        string? stringValue = value switch
        {
            OdometerUnit.Mi => "mi",
            OdometerUnit.Km => "km",
            _ => null,
        };

        writer.WriteStringValue(stringValue);
    }
}
