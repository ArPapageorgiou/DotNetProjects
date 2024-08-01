using System.Text.Json.Serialization;

namespace Domain.WeatherBitApi_Models
{
    public class Weather
    {
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
