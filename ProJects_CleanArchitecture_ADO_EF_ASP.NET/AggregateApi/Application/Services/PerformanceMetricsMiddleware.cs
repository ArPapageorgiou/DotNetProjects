namespace Application.Services
{
    using System.Diagnostics;
    using Domain.ApiRequestStatistic;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Http;
    using System.Net.Http;

    public class PerformanceMetricsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestStatisticRepository _requestStatisticRepository;

        public PerformanceMetricsMiddleware(RequestDelegate next, IRequestStatisticRepository requestStatisticRepository)
        {
            _next = next;
            _requestStatisticRepository = requestStatisticRepository;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopWatch = Stopwatch.StartNew();
            try
            {
                await _next(context);
            }
            finally
            {
                stopWatch.Stop();

                var apiName = context.Request.Path;
                var responseTime = stopWatch.ElapsedMilliseconds;

                _requestStatisticRepository.AddRequestStatistics(new RequestStatistic
                {
                    ApiName = apiName,
                    ResponseTime = responseTime,
                    Timestamp = DateTime.Now
                });
            }
        }
    }
}
