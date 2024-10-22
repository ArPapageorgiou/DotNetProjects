using Application.Interfaces;
using Domain.AggregateModels;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class AggregateService : IAggregateService
    {
        private readonly IWeatherService _weatherService;
        private readonly INewsApiService _newsApiService;
        private readonly IFootballStandingsService _footballStandingsService;
        private readonly ILogger<AggregateService> _logger;

        public AggregateService(IWeatherService weatherService, INewsApiService newsApiService, IFootballStandingsService footballStandingsService, ILogger<AggregateService> logger)
        {
            _weatherService = weatherService;
            _newsApiService = newsApiService;
            _footballStandingsService = footballStandingsService;
            _logger = logger;
        }

        public async Task<AggregateModel> GetAggregateDataAsync(string temperature, bool ascending, string keyword)
        {
            var newsTask = _newsApiService.GetNewsDataAsync(keyword);
            var weatherTask = _weatherService.GetWeatherDataAsync(temperature, ascending);
            var footballTask = _footballStandingsService.GetFootbalStandingsAsync();

            try
            {
                await Task.WhenAll(newsTask, weatherTask, footballTask);
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.InnerExceptions)
                {
                    _logger.LogError(exception, "Error occurred while fetching data from one of the APIs.");
                    Console.WriteLine(exception.Message);
                }
            }

            var newsApiResponse = await newsTask;
            var weatherApiResponse = await weatherTask;
            var footballApiResponse = await footballTask;

            var aggregateModel = new AggregateModel
            {
                NewsApiResponse = newsApiResponse,
                WeatherData = weatherApiResponse,
                ApiResponse = footballApiResponse
            };

            return aggregateModel;
        }
    }
}
