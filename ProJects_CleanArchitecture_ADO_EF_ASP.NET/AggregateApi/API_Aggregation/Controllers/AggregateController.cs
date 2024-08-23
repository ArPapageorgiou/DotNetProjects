using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.ApiRequestStatistic;
using Domain.NewsApi_ModelClasses;
using System.Formats.Asn1;


namespace API_Aggregation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AggregateController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly IFootballStandingsService _footballStandingsService;
        private readonly IRequestStatisticsService _requestStatisticsService;
        private readonly INewsApiService _newsApiService;
        private readonly IAggregateService _aggregateService;

        public AggregateController(IWeatherService weatherService, IRequestStatisticsService requestStatisticsService, IFootballStandingsService footballStandingsService, INewsApiService newsApiService, IAggregateService aggregateService)
        {
            _weatherService = weatherService;
            _requestStatisticsService = requestStatisticsService;
            _footballStandingsService = footballStandingsService;
            _newsApiService = newsApiService;
            _aggregateService = aggregateService;   
        }

        [HttpGet ("aggregateData")]
        public async Task<IActionResult> GetAggregateData(string temperature, bool ascending, string newsKeyword)
        {
            if (string.IsNullOrEmpty(newsKeyword))
            {
                return BadRequest("News Keyword cannot be null or empty");
            }

            try
            {
                var response = await _aggregateService.GetAggregateDataAsync(temperature, ascending, newsKeyword);

                if (response == null)
                {
                    return NotFound("No results found.");
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[HttpGet ("newsData")]
        //public async Task<IActionResult> GetNewsDataAsync(string keyword)
        //{
        //    var newsData = await _newsApiService.GetNewsDataAsync(keyword);
        //    return Ok(newsData);
        //}

        //[HttpGet("weatherData")]
        //public async Task<IActionResult> GetWeatherData(string sortByTemperature = "temperature", bool ascending = true)
        //{
        //    var weatherData = await _weatherService.GetWeatherData(sortByTemperature, ascending);
        //    return Ok(weatherData);
        //}

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
