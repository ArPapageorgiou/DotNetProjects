using Domain.WeatherBitApi_Models;

namespace Application.Interfaces
{
    public interface IWeatherHttpClient
    {
        Task<WeatherData> GetWeatherAsync(string countryCode, string cityName);
    }
}
