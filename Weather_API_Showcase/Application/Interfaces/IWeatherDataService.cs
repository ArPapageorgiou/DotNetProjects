using Domain.Models;

namespace Application.Interfaces
{
    public interface IWeatherDataService
    {
        Task<WeatherData> GetWeatherAsync(string CountryCode, string CityName, bool forceRefresh);

    }
}
