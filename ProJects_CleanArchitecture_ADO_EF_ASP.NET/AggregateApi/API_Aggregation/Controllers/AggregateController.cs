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
        private readonly IFootballStandingsService _footballStandingsService;
        private readonly IRequestStatisticsService _requestStatisticsService;

        public AggregateController(IWeatherService weatherService, IRequestStatisticsService requestStatisticsService, IFootballStandingsService footballStandingsService)
        {
            _weatherService = weatherService;
            _requestStatisticsService = requestStatisticsService;
            _footballStandingsService = footballStandingsService;
        }

        [HttpGet("weatherData")]
        public async Task<IActionResult> GetWeatherData(string sortByTemperature = "temperature", bool ascending = true)
        {
            var weatherData = await _weatherService.GetWeatherData(sortByTemperature, ascending);
            return Ok(weatherData);
        }

        //[HttpGet("footballStandingData")]

        //public async Task<IActionResult> GetFootballStandingDataAsync()
        //{
        //    var footballStandingData = await _footballStandingsService.GetFootbalStandingsAsync();

        //    return Ok(footballStandingData);
        //}

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
