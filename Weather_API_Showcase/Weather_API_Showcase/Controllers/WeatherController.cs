using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using System.Text.Json;

namespace Weather_API_Showcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IHttpClientRepository _httpClientRepository;
        public WeatherController(IHttpClientRepository httpClientRepository)
        {
                _httpClientRepository = httpClientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<WeatherData>> GetWeather(string countryCode, string cityName) 
        {
            var weatherData = await _httpClientRepository.GetWeatherHttpClientAsync(countryCode, cityName);
            return Ok(weatherData);
        }
    }
}
