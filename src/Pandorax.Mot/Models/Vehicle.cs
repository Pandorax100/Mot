using System.Text.Json.Serialization;

namespace Pandorax.Mot.Models
{
    /// <summary>
    /// Vehicle data for vehicles with at least one MOT test.
    /// </summary>
    public class Vehicle
    {
        [JsonPropertyName("hasOutstandingRecall")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OutstandingRecallStatus HasOutstandingRecall { get; set; }

        /// <summary>
        /// Registration number of the vehicle.
        /// </summary>
        [JsonPropertyName("registration")]
        public string? Registration { get; set; }

        /// <summary>
        /// The vehicle make.
        /// </summary>
        [JsonPropertyName("make")]
        public string? Make { get; set; }

        /// <summary>
        /// The vehicle model.
        /// </summary>
        [JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Date the vehicle is first used in Great Britain, Northern Ireland or abroad.
        /// </summary>
        [JsonPropertyName("firstUsedDate")]
        public DateOnly? FirstUsedDate { get; set; }

        /// <summary>
        /// The type of fuel the vehicle uses.
        /// </summary>
        [JsonPropertyName("fuelType")]
        public string? FuelType { get; set; }

        [JsonPropertyName("primaryColour")]
        public string? PrimaryColour { get; set; }

        /// <summary>
        /// Date the vehicle is first registered in Great Britain, Northern Ireland or abroad.
        /// </summary>
        [JsonPropertyName("registrationDate")]
        public DateOnly? RegistrationDate { get; set; }

        /// <summary>
        /// Date the vehicle was manufactured.
        /// </summary>
        [JsonPropertyName("manufactureDate")]
        public DateOnly? ManufactureDate { get; set; }

        /// <summary>
        /// Engine cylinder capacity (cc) of the vehicle.
        /// </summary>
        [JsonPropertyName("engineSize")]
        public string? EngineSize { get; set; }

        [JsonPropertyName("motTests")]
        public List<MotTest> MotTests { get; set; } = [];
    }
}
