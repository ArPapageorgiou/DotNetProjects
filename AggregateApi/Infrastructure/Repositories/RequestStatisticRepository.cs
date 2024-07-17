using Application.Interfaces;
using Domain.ApiRequestStatistic;
using System.Collections.Concurrent;

namespace Infrastructure.Repositories
{
    internal class RequestStatisticRepository : IRequestStatisticRepository
    {
        private readonly ConcurrentBag<RequestStatistic> _requestStatistics = new ConcurrentBag<Domain.ApiRequestStatistic.RequestStatistic>();
        
        public void AddRequestStatistics(RequestStatistic requestStatistic)
        {
            _requestStatistics.Add(requestStatistic);
        }

        public IEnumerable<RequestStatistic> GetStatistic()
        {
            return _requestStatistics;
        }
    }
}
