using Domain.ApiRequestStatistic;

namespace Application.Interfaces
{
    public interface IRequestStatisticRepository
    {
        void AddRequestStatistics(RequestStatistic requestStatistic); 

        IEnumerable<RequestStatistic> GetStatistics();
    }
}
