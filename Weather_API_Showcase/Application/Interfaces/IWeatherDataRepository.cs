using Domain.Models;

namespace Application.Interfaces
{
    public interface IWeatherDataRepository
    {
        Task<WeatherData> GetWeatherDataAsync(string CountryCode, string CityName);
        Task SetWeatherDataAsync(WeatherData weatherData);
        
    }
}
