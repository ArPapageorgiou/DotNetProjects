using Domain.ApiRequestStatistic;

namespace Application.Interfaces
{
    public interface IRequestStatisticsService
    {
       IEnumerable<ApiRequestStatistics> GetRequestStatisticsService();
    }
}
