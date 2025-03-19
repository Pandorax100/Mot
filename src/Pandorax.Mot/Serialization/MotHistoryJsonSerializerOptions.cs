using System.Text.Json;
using Pandorax.Mot.Serialization.Converters;

namespace Pandorax.Mot.Serialization;

internal sealed class MotHistoryJsonSerializerOptions
{
    public static JsonSerializerOptions JsonSerializerOptions { get; } = BuildOptions();

    private static JsonSerializerOptions BuildOptions()
    {
        JsonSerializerOptions options = new(JsonSerializerDefaults.Web);

        options.Converters.Add(new DefectTypeConverter());

        return options;
    }
}
