using System.Text.Json;
using System.Text.Json.Serialization;
using Pandorax.Mot.Models;

namespace Pandorax.Mot.Converters;

internal class TestResultConverter : JsonConverter<TestResult>
{
    public override TestResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        return value switch
        {
            "FAILED" => TestResult.Failed,
            "PASSED" => TestResult.Passed,
            _ => throw new ArgumentOutOfRangeException(nameof(reader), $"The value {value} cannot be converted to TestResult"),
        };
    }

    public override void Write(Utf8JsonWriter writer, TestResult value, JsonSerializerOptions options)
    {
        string? stringValue = value switch
        {
            TestResult.Failed => "FAILED",
            TestResult.Passed => "PASSED",
            _ => null,
        };

        writer.WriteStringValue(stringValue);
    }
}
