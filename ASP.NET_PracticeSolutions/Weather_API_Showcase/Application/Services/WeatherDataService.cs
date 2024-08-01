
﻿using Application.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Application.Services
{
    public class WeatherDataService : IWeatherDataService
    {
        private readonly IHttpClientRepository _httpClientRepository;
        private readonly IWeatherDataRepository _weatherDataRepository;
        private readonly ICacheAccess _cacheAccess;
        private readonly ILogger<WeatherDataService> _logger;

        public WeatherDataService(IHttpClientRepository httpClientRepository, IWeatherDataRepository weatherDataRepository, ICacheAccess cacheAccess, ILogger<WeatherDataService> logger)
        {
            _httpClientRepository = httpClientRepository;
            _weatherDataRepository = weatherDataRepository;
            _cacheAccess = cacheAccess;
            _logger = logger;
        }

        public async Task<WeatherData> GetWeatherAsync(string CountryCode, string CityName, bool forceRefresh = false)
        {
            try
            {
                if (string.IsNullOrEmpty(CountryCode) || string.IsNullOrEmpty(CityName))
                {
                    throw new ArgumentException("Country Code and City name cannot be null or empty");
                }

                var data = new WeatherData();

                if (forceRefresh)
                {
                    data = await _cacheAccess.GetDataAsync(CountryCode, CityName);
                    if (data != null)
                    {
                        return data;
                    }

                    data = await _weatherDataRepository.GetWeatherDataAsync(CountryCode, CityName);
                    if (data != null)
                    {
                        await _cacheAccess.SetDataAsync(data);
                        return data;
                    }
                }

                data = await _httpClientRepository.GetWeatherHttpClientAsync(CountryCode, CityName);
                if (data != null)
                {
                    await _cacheAccess.SetDataAsync(data);
                    await _weatherDataRepository.SetWeatherDataAsync(data);
                    return data;
                }

                throw new Exception("Weather data not found");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting weather data from a source for the application the service");
                throw new Exception(ex.Message);
            }
        }

    }
}
