using Domain.Models;

namespace Application.Interfaces
{
    public interface ICacheAccess
    {

        Task<WeatherData> GetDataAsync(string countryCode, string cityName); 
        Task SetDataAsync(WeatherData weatherData);  
        string GenerateCacheKey(string countryCode, string cityName);


    }
}
