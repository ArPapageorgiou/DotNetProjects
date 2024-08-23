using Domain.WeatherBitApi_Models;

namespace Application.Interfaces
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherData>> GetWeatherDataAsync(string sortByTemperature, bool ascending);
    }
}
