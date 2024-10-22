using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Services;

namespace Infrastructure.Infrastructure_Module
{
    public static class InfraModule
    {
        public static IServiceCollection InfraServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpClient("WeatherApi", client =>
            {
                client.BaseAddress = new Uri(configuration["ApiSettings:WeatherBitUrl"]);
                client.DefaultRequestHeaders.Add("Api-Client", configuration["ApiSettings:WeatherBitName"]);
            }).AddHttpMessageHandler<ApiPerformanceHandler>(); 
            
            service.AddHttpClient("FootballApi", client =>
            { 
                client.BaseAddress = new Uri(configuration["ApiSettings:FootballAPIUrl"]);
                client.DefaultRequestHeaders.Add("x-apisports-key", configuration["ApiSettings:FootballAPIApiKey"]);
                client.DefaultRequestHeaders.Add("x-rapidapi-host", configuration["ApiSettings:FootballAPIHost"]);
                client.DefaultRequestHeaders.Add("Api-Client", configuration["ApiSettings:FootballApiName"]);
            }).AddHttpMessageHandler<ApiPerformanceHandler>();

            service.AddHttpClient("NewsApi", client =>
            {
                client.BaseAddress = new Uri(configuration["ApiSettings:NewsApiUrl"]);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(configuration["ApiSettings:NewsApiUserAgent"]);
                client.DefaultRequestHeaders.Add("Api-Client", configuration["ApiSettings:NewsApiName"]);
            }).AddHttpMessageHandler<ApiPerformanceHandler>();

            service.AddScoped<IWeatherHttpClient, WeatherHttpClient>();
            service.AddScoped<IFootballAPI_HttpClient, FootballAPI_HttpClient>();
            service.AddScoped<INewsAPI_HttpClient, NewsAPI_HttpClient>();
            service.AddSingleton<IRequestStatisticRepository, RequestStatisticRepository>();
            return service;
        }
    }
}
