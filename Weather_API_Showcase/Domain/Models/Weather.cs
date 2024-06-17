using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Weather
    {
        public int Id { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        public Data Db_Data { get; set; }
    }
}
