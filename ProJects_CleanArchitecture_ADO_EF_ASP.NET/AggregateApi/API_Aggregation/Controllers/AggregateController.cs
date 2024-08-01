using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.ApiRequestStatistic;

namespace API_Aggregation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AggregateController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly IRequestStatisticsService _requestStatisticsService;

        public AggregateController(IWeatherService weatherService, IRequestStatisticsService requestStatisticsService)
        {
            _weatherService = weatherService;
            _requestStatisticsService = requestStatisticsService;
        }

        [HttpGet("weatherData")]
        public async Task<IActionResult> GetWeatherData(string sortByTemperature = "temperature", bool ascending = true)
        {
            var weatherData = await _weatherService.GetWeatherData(sortByTemperature, ascending);
            return Ok(weatherData);
        }

        [HttpGet("statistics")]
        public ActionResult<ApiRequestStatistics> GetRequestStatistics()
        {
            try
            {
                var requestData = _requestStatisticsService.GetRequestStatisticsService();
                return Ok(requestData);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong with our server. Try again.");
            }
        }
    }
}
