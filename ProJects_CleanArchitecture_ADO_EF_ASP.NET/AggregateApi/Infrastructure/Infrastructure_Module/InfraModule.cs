using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Infrastructure_Module
{
    public static class InfraModule
    {
        public static IServiceCollection InfraServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpClient();
            service.AddHttpClient<IFootballAPI_HttpClient, FootballAPI_HttpClient>(client =>
            { 
                client.BaseAddress = new Uri(configuration["ApiSettings:FootballAPIUrl"]);
                client.DefaultRequestHeaders.Add("football_api_host", configuration["ApiSettings:FootballAPIHost"]);
                client.DefaultRequestHeaders.Add("football_api_key", configuration["ApiSettings:FootballAPIApiKey"]);
            });


            service.AddScoped<IWeatherHttpClient, WeatherHttpClient>();
            service.AddScoped<IFootballAPI_HttpClient, FootballAPI_HttpClient>();
            service.AddSingleton<IRequestStatisticRepository, RequestStatisticRepository>();
            return service;
        }
    }
}
