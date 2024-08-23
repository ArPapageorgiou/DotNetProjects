using Application.Interfaces;
using Domain.WeatherBitApi_Models;
using Application.AppConstants;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherHttpClient _weatherHttpClient;
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<IWeatherService> _logger;

        public WeatherService(IWeatherHttpClient weatherHttpClient, IDistributedCache distributedCache, ILogger<IWeatherService> logger)
        {
            _weatherHttpClient = weatherHttpClient;
            _distributedCache = distributedCache;
            _logger = logger;
        }

        public async Task<IEnumerable<WeatherData>> GetWeatherDataAsync(string sortByTemperature = "temperature", bool ascending = true)
        {
            var cacheKey = GetCacheKey(sortByTemperature, ascending);
            _logger.LogInformation($"Fetching data from cache with key: {cacheKey}");

            //Attempt to fetch Data from cache
            var weatherResponse = await _distributedCache.GetRecordAsync<IEnumerable<WeatherData>>(cacheKey, GetJsonSerializerOptions());
            
            //Attempt to fetch data from Api if not in cache
            if(weatherResponse == null)
            {
                _logger.LogInformation("Data not found in cache. Fetching from API.");
                weatherResponse = await FetchWeatherDataFromApi();

                if (weatherResponse == null)
                {
                    _logger.LogInformation("API response is null. Creating default response.");
                    weatherResponse = await CreateDefaultApiResponse();
                }
                else
                {
                    _logger.LogInformation("Data fetched from API. Setting data in cache.");
                    await _distributedCache.SetRecordAsync(GetCacheKey(sortByTemperature, ascending), weatherResponse);
                }
            }
            else
            {
                _logger.LogInformation("Data fetched from cache.");
            }

            if (sortByTemperature == "temperature")
            {
                weatherResponse = await SortByTemperature(ascending, weatherResponse);
            }

            return weatherResponse;

        }

        private static string GetCacheKey(string sortByTemperature, bool ascending)
        {
            var keyParts = new List<string>();

            if (!string.IsNullOrEmpty(sortByTemperature))
            {
                keyParts.Add($"SortBy_{sortByTemperature}");
            }
            
            keyParts.Add($"Ascending_{ascending}");

            if (keyParts.Count == 1)
            {
                return "defaultWeatherCacheKey";
            }

            var cacheKey = string.Join(",", keyParts);
            return cacheKey;
        }

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        }

        private async Task<IEnumerable<WeatherData>> FetchWeatherDataFromApi()
        {
            var cityList = CityName.GetCityNames();
            var weatherDataList = new List<WeatherData>();

            try
            {
                foreach (var city in cityList)
                {
                    var cityWeather = await _weatherHttpClient.GetWeatherAsync(CountryCode.Greece, city);
                    weatherDataList.Add(cityWeather);
                }

                return weatherDataList;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching data from API: {ex.Message}");
                return null;
            }
            
        }

        private async Task<IEnumerable<WeatherData>> CreateDefaultApiResponse()
        {
            var defaultResponse = new List<WeatherData>()
            {
                new WeatherData
                {
                    DataList = new List<Data>
                    {
                        new Data
                        {
                            WindCdir = "N/A",
                            Rh = -1,
                            Pod = "N/A",
                            Lon = -1,
                            Pres = -1,
                            Timezone = "N/A",
                            ObTime = "N/A",
                            CountryCode = "N/A",
                            Clouds = -1,
                            Vis = -1,
                            WindSpd = -1,
                            Gust = -1,
                            WindCdirFull = "N/A",
                            AppTemp = -1,
                            StateCode = "N/A",
                            Ts = 0,
                            HAngle = -1,
                            Dewpt = -1,
                            Weather = new Weather
                            {
                                Icon = "N/A",
                                Code = -1,
                                Description = "Error: No data available"
                            },
                            Uv = -1,
                            Aqi = -1,
                            Station = "N/A",
                            Sources = new List<string> { "N/A" },
                            WindDir = -1,
                            ElevAngle = -1,
                            Datetime = "N/A",
                            Precip = -1,
                            Ghi = -1,
                            Dni = -1,
                            Dhi = -1,
                            SolarRad = -1,
                            CityName = "Unknown",
                            Sunrise = "N/A",
                            Sunset = "N/A",
                            Temp = -999,
                            Lat = -1,
                            Slp = -1
                        }
                    },
                    Count = 1
                }
                
            };
            
            return defaultResponse;

        }

        private async Task<IEnumerable<WeatherData>> SortByTemperature(bool ascending, IEnumerable<WeatherData> weatherResponse)
        {
            var sortedResponse = ascending ? weatherResponse.OrderBy(w => w.DataList.FirstOrDefault()?.Temp).ToList()
                : weatherResponse.OrderByDescending(w => w.DataList.FirstOrDefault()?.Temp).ToList();

                return sortedResponse;
        }
    }
}
