using Application.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    internal class CacheAccess : ICacheAccess
    {
        private readonly IMemoryCache _cache;

        public CacheAccess(IMemoryCache cache)
        {
            _cache = cache;
        }

        public string GenerateCacheKey(string countryCode, string cityName)
        {
            string key = $"{countryCode}_{cityName}";
            return key;
        }

        public async Task<WeatherData> GetDataAsync(string countryCode, string cityName)
        {
            string key = GenerateCacheKey(countryCode, cityName);
            var result = _cache.Get<WeatherData>(key);
            return result;
        }

        public async Task SetDataAsync(WeatherData weatherData)
        {
            foreach(var item in weatherData.DataList)
            {
                var key = GenerateCacheKey(item.CountryCode, item.CityName);
                _cache.Set(key, weatherData, TimeSpan.FromMinutes(60));
            }
        }

        
        
    }
}
