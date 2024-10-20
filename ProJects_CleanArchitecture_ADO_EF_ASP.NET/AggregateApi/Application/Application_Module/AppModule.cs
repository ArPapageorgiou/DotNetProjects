using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Application_Module
{
    public static class AppModule
    {
        public static IServiceCollection AppServices(this IServiceCollection service)
        {
            service.AddScoped<IRequestStatisticsService, RequestStatisticsService>();
            service.AddScoped<IWeatherService, WeatherService>();
            service.AddScoped<IFootballStandingsService, FootballStandingsService>();
            service.AddScoped<INewsApiService, NewsApiService>();
            service.AddScoped<IAggregateService, AggregateService>();
            service.AddTransient<ApiPerformanceHandler>();
            return service;
        }
    }
}
