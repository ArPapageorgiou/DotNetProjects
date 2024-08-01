using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class WeatherData
    {
        public int Id { get; set; }

        [JsonPropertyName("data")]
        public List<Data> DataList { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

    }
}
