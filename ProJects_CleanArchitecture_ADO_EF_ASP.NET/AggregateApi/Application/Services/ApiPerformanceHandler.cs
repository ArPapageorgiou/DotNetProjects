using Application.Interfaces;
using System.Diagnostics;
using Domain.ApiRequestStatistic;


namespace Application.Services
{
    public class ApiPerformanceHandler : DelegatingHandler
    {
        private readonly IRequestStatisticRepository _requestStatisticRepository;

        public ApiPerformanceHandler(IRequestStatisticRepository requestStatisticRepository)
        {
            _requestStatisticRepository = requestStatisticRepository;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
        {
            var stopWatch = Stopwatch.StartNew();
            var response = await base.SendAsync(requestMessage, cancellationToken);
            stopWatch.Stop();

            var apiClient = requestMessage.Headers.Contains("Api-Client")
                ? requestMessage.Headers.GetValues("Api-Client").FirstOrDefault()
                : requestMessage.RequestUri.ToString();

            _requestStatisticRepository.AddRequestStatistics(new RequestStatistic
            {
                ApiName = apiClient,
                ResponseTime = stopWatch.ElapsedMilliseconds,
                Timestamp = DateTime.Now
            });

            return response;
        }
    }
}
