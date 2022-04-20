namespace Pandorax.Mot.Configuration;

/// <summary>
/// A class containing constants for the MOT services.
/// </summary>
internal static class MotConstants
{
    /// <summary>
    /// The name of the http header used to provide the API key.
    /// </summary>
    public const string ApiKeyHeaderName = "x-api-key";

    /// <summary>
    /// The default base address of the MOT API.
    /// </summary>
    public const string DefaultBaseAddress = "https://beta.check-mot.service.gov.uk/";
}
