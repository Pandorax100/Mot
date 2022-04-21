using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pandorax.Mot.Converters;

internal class DotSeparatedDateConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value is null ? null : DateTime.ParseExact(value, "yyyy.MM.dd", CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
