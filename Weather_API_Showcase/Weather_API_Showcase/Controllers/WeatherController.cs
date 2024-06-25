using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace Weather_API_Showcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        private readonly IWeatherDataService _weatherDataService;
        public WeatherController(IWeatherDataService weatherDataService)
        {
            _weatherDataService = weatherDataService;

        }

        [HttpGet]
        public async Task<ActionResult<WeatherData>> GetWeather(string countryCode, string cityName) 
        {
            var weatherData = await _weatherDataService.GetWeatherAsync(countryCode, cityName, false);
            return Ok(weatherData);
        }
    }
}
