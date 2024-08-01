using System.Text.Json.Serialization;

namespace Domain.WeatherBitApi_Models
{
    public class WeatherData
    {
        [JsonPropertyName("data")]
        public List<Data> DataList { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
