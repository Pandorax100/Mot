using System.Text.Json;
using System.Text.Json.Serialization;
using Pandorax.Mot.Models;

namespace Pandorax.Mot.Converters;

internal class CommentTypeConverter : JsonConverter<CommentType>
{
    public override CommentType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            "ADVISORY" => CommentType.Advisory,
            "FAIL" => CommentType.Fail,
            "MINOR" => CommentType.Minor,
            "PRS" => CommentType.Prs,
            "USER ENTERED" => CommentType.UserEntered,
            _ => throw new ArgumentOutOfRangeException(nameof(reader), $"The value {value} cannot be converted to CommentType"),
        };
    }

    public override void Write(Utf8JsonWriter writer, CommentType value, JsonSerializerOptions options)
    {
        string? stringValue = value switch
        {
            CommentType.Advisory => "ADVISORY",
            CommentType.Fail => "FAIL",
            CommentType.Minor => "MINOR",
            CommentType.Prs => "PRS",
            CommentType.UserEntered => "USER ENTERED",
            _ => null,
        };

        writer.WriteStringValue(stringValue);
    }
}
