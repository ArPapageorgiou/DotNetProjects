using Domain.Models;

namespace Application.Interfaces
{
    public interface IHttpClientRepository
    {
        Task<WeatherData> GetWeatherHttpClientAsync(string CountryCode, string CityName);
    }
}
