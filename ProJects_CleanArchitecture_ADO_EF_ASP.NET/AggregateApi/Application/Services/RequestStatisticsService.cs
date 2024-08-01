using Application.Interfaces;
using Domain.ApiRequestStatistic;

namespace Application.Services
{
    public class RequestStatisticsService : IRequestStatisticsService
    {
        private readonly IRequestStatisticRepository _requestStatisticRepository;

        public RequestStatisticsService(IRequestStatisticRepository requestStatisticRepository)
        {
            _requestStatisticRepository = requestStatisticRepository;
        }

        public IEnumerable<ApiRequestStatistics> GetRequestStatisticsService()
        {
            var allStatistics = _requestStatisticRepository.GetStatistics();
            var groupByApi = allStatistics.GroupBy(a => a.ApiName);
            var result = new List<ApiRequestStatistics>();

            foreach(var apiGroup in groupByApi)
            {
                var apiName = apiGroup.Key;
                var totalRequests = apiGroup.Count();

                var fastRequests = apiGroup.Where(stat => stat.ResponseTime < 100).ToList();
                var averageRequests = apiGroup.Where(stat => stat.ResponseTime >= 100 && stat.ResponseTime < 200).ToList();
                var slowRequests = apiGroup.Where(stat => stat.ResponseTime >= 200).ToList();

                var fastAverageTime = fastRequests.Any() ? fastRequests.Average(stat => stat.ResponseTime) : 0;
                var averageAverageTime = averageRequests.Any() ? averageRequests.Average(stat => stat.ResponseTime) : 0;
                var slowAverageTime = slowRequests.Any() ? slowRequests.Average(stat => stat.ResponseTime) : 0;


                result.Add(new ApiRequestStatistics
                {
                    ApiName = apiName,
                    TotalRequests = totalRequests,
                    FastRequests = fastRequests.Count,
                    AverageRequests = averageRequests.Count,
                    SlowRequests = slowRequests.Count,
                    FastAverageTime = fastAverageTime,
                    AverageAverageTime = averageAverageTime,
                    SlowAverageTime = slowAverageTime,

                });

            }

            return result;

        }
    }
}
