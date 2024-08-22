using Domain.FootballAPI_ModelClasses.ApiFootball;
using Domain.NewsApi_ModelClasses;
using Domain.WeatherBitApi_Models;

namespace Domain.AggregateModels
{
    public class AggregateModel
    {
        public NewsApiResponse NewsApiResponse { get; set; }
        public IEnumerable<WeatherData> WeatherData { get; set; }
        public ApiResponse ApiResponse { get; set; }
    }
}
