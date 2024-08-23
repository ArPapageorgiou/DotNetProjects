using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Infrastructure_Module
{
    public static class InfraModule
    {
        public static IServiceCollection InfraServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpClient("WeatherApi", client =>
            {
                client.BaseAddress = new Uri(configuration["ApiSettings:WeatherBitUrl"]);
            });
            
            service.AddHttpClient("FootballApi", client =>
            { 
                client.BaseAddress = new Uri(configuration["ApiSettings:FootballAPIUrl"]);
                client.DefaultRequestHeaders.Add("x-apisports-key", configuration["ApiSettings:FootballAPIApiKey"]);
                client.DefaultRequestHeaders.Add("x-rapidapi-host", configuration["ApiSettings:FootballAPIHost"]);
            });

            service.AddHttpClient("NewsApi", client =>
            {
                client.BaseAddress = new Uri(configuration["ApiSettings:NewsApiUrl"]);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(configuration["ApiSettings:NewsApiUserAgent"]);
            });

            service.AddScoped<IWeatherHttpClient, WeatherHttpClient>();
            service.AddScoped<IFootballAPI_HttpClient, FootballAPI_HttpClient>();
            service.AddScoped<INewsAPI_HttpClient, NewsAPI_HttpClient>();
            service.AddSingleton<IRequestStatisticRepository, RequestStatisticRepository>();
            return service;
        }
    }
}
