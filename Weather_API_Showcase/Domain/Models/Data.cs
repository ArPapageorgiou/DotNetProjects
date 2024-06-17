using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Data
    {
        public int Id { get; set; }

        [JsonPropertyName("wind_cdir")]
        public string WindCdir { get; set; }

        [JsonPropertyName("rh")]
        public float Rh { get; set; }

        [JsonPropertyName("pod")]
        public string Pod { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("pres")]
        public double Pres { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("ob_time")]
        public string ObTime { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("clouds")]
        public float Clouds { get; set; }

        [JsonPropertyName("vis")]
        public float Vis { get; set; }

        [JsonPropertyName("wind_spd")]
        public double WindSpd { get; set; }

        [JsonPropertyName("gust")]
        public double Gust { get; set; }

        [JsonPropertyName("wind_cdir_full")]
        public string WindCdirFull { get; set; }

        [JsonPropertyName("app_temp")]
        public double AppTemp { get; set; }

        [JsonPropertyName("state_code")]
        public string StateCode { get; set; }

        [JsonPropertyName("ts")]
        public long Ts { get; set; }

        [JsonPropertyName("h_angle")]
        public float HAngle { get; set; }

        [JsonPropertyName("dewpt")]
        public double Dewpt { get; set; }

        public Weather Weather { get; set; }

        [JsonPropertyName("uv")]
        public float Uv { get; set; }

        [JsonPropertyName("aqi")]
        public float Aqi { get; set; }

        [JsonPropertyName("station")]
        public string Station { get; set; }

        public List<string> Sources { get; set; }

        [JsonPropertyName("wind_dir")]
        public float WindDir { get; set; }

        [JsonPropertyName("elev_angle")]
        public double ElevAngle { get; set; }

        [JsonPropertyName("datetime")]
        public string Datetime { get; set; }

        [JsonPropertyName("precip")]
        public double Precip { get; set; }

        [JsonPropertyName("ghi")]
        public double Ghi { get; set; }

        [JsonPropertyName("dni")]
        public double Dni { get; set; }

        [JsonPropertyName("dhi")]
        public double Dhi { get; set; }

        [JsonPropertyName("solar_rad")]
        public double SolarRad { get; set; }

        [JsonPropertyName("city_name")]
        public string CityName { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("slp")]
        public double Slp { get; set; }

        public int WeatherDataForeignKey { get; set; }
        public int WeatherId { get; set; }
        public WeatherData WeatherData { get; set; }
    }
}
