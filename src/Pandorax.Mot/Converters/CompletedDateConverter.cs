using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pandorax.Mot.Converters;

internal class CompletedDateConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString()!;

        return DateTime.ParseExact(value, "yyyy.MM.dd HH:mm:ss", CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
