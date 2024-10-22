using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.ApiRequestStatistic;


namespace API_Aggregation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AggregateController : ControllerBase
    {
        private readonly IRequestStatisticsService _requestStatisticsService;
        private readonly IAggregateService _aggregateService;

        public AggregateController(IRequestStatisticsService requestStatisticsService, IAggregateService aggregateService)
        {
            _requestStatisticsService = requestStatisticsService;
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

        [HttpGet("statistics")]
        public ActionResult<IEnumerable<ApiRequestStatistics>> GetRequestStatistics()
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
