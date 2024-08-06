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

            
            service.AddHttpClient("FootballAPI", client =>
            { 
                client.BaseAddress = new Uri(configuration["ApiSettings:FootballAPIUrl"]);
                client.DefaultRequestHeaders.Add("x-apisports-key", configuration["ApiSettings:FootballAPIApiKey"]);
                client.DefaultRequestHeaders.Add("x-rapidapi-host", configuration["ApiSettings:FootballAPIHost"]);

            });


            service.AddScoped<IWeatherHttpClient, WeatherHttpClient>();
            service.AddScoped<IFootballAPI_HttpClient, FootballAPI_HttpClient>();
            service.AddSingleton<IRequestStatisticRepository, RequestStatisticRepository>();
            return service;
        }
    }
}
