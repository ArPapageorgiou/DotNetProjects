using Domain.WeatherBitApi_Models;

namespace Application.Interfaces
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherData>> GetWeatherData(string sortByTemperature, bool ascending);
    }
}
