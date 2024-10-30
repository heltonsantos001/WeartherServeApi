using System.Text.Json.Serialization;


namespace WeartherServeApi.Model
{
    public class GeoLocationModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }
}
