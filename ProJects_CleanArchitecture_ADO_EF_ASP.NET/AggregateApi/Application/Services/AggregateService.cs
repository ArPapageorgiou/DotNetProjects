using Application.Interfaces;
using Domain.AggregateModels;

namespace Application.Services
{
    public class AggregateService : IAggregateService
    {
        private readonly IWeatherService _weatherService;
        private readonly INewsApiService _newsApiService;
        private readonly IFootballStandingsService _footballStandingsService;

        public AggregateService(IWeatherService weatherService, INewsApiService newsApiService, IFootballStandingsService footballStandingsService)
        {
            _weatherService = weatherService;
            _newsApiService = newsApiService;
            _footballStandingsService = footballStandingsService;
        }

        public async Task<AggregateModel> GetAggregateDataAsync(string temperature, bool ascending, string keyword)
        {
            var newsTask = _newsApiService.GetNewsDataAsync(keyword);
            var weatherTask = _weatherService.GetWeatherData(temperature, ascending);
            var footballTask = _footballStandingsService.GetFootbalStandingsAsync();

            await Task.WhenAll(newsTask, weatherTask, footballTask);

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
