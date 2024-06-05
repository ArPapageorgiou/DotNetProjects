using System.Text.Json;
using Domain;

namespace Application
{
    public class WeatherHttpClient : IWeatherHttpClient
    {
        private readonly HttpClient _httpClient;

        public WeatherHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task GetWeatherData()
        {
            try
            {
                _httpClient.BaseAddress = new Uri("http://api.weatherbit.io/v2.0/current ");

                var apiKey = "c969571a57e44642be74e4a2373949bd";
                var url = $"/current?key={apiKey}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode) 
                { 
                    var responseBody = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    var weatherData = JsonSerializer.Deserialize<List<Data>>(responseBody, options);

                    if (weatherData is not null) 
                    {
                        foreach (var item in weatherData) 
                        {
                            await Console.Out.WriteLineAsync($"City Name: {item.CityName}\n" + 
                                $"Temperature: {item.Temp} \n" + 
                                $"Description: {item.Weather.Description}\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
