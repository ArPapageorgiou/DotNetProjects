using Domain.Models;

namespace Application.Interfaces
{
    public interface ICacheAccess
    {
        WeatherData GetData(string countryCode, string cityName); 
        void SetData(WeatherData weatherData);  
    }
}
