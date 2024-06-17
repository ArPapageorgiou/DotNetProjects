using Application.Interfaces;
using Domain.Models;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public class HttpClientRepository : IHttpClientRepository
    {

        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://api.weatherbit.io/v2.0/current";
        private const string ApiKey = "c969571a57e44642be74e4a2373949bd";

        public HttpClientRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherHttpClientAsync(string CountryCode, string CityName)
        {
            try
            {
                WeatherData weatherData = new WeatherData();

                var url = $"{BaseUrl}?&city={CityName}&country={CountryCode}&key={ApiKey}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();


                    var options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    weatherData = JsonSerializer.Deserialize<WeatherData>(responseBody, options);

                    return weatherData;
                }
                else
                {
                    throw new Exception();
                }

                 
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
