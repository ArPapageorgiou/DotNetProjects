using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.WeatherBitApi_Models;

namespace API_Aggregation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WeatherBitController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherBitController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherData(string sortByTemperature = "temperature", bool ascending = true)
        {
            var weatherData = await _weatherService.GetWeatherData(sortByTemperature, ascending);
            return Ok(weatherData);
        }
    }
}
