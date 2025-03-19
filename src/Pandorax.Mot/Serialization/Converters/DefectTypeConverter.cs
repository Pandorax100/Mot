using System.Text.Json;
using System.Text.Json.Serialization;
using Pandorax.Mot.Models;

namespace Pandorax.Mot.Serialization.Converters;

internal sealed class DefectTypeConverter : JsonConverter<DefectType>
{
    public override DefectType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            "ADVISORY" => DefectType.Advisory,
            "DANGEROUS" => DefectType.Dangerous,
            "FAIL" => DefectType.Fail,
            "MAJOR" => DefectType.Major,
            "MINOR" => DefectType.Minor,
            "NON SPECIFIC" => DefectType.NonSpecific,
            "SYSTEM GENERATED" => DefectType.SystemGenerated,
            "USER ENTERED" => DefectType.UserEntered,
            "PRS" => DefectType.Prs,
            _ => throw new ArgumentOutOfRangeException(nameof(reader), $"The value {value} cannot be converted to DefectType"),
        };
    }

    public override void Write(Utf8JsonWriter writer, DefectType value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
