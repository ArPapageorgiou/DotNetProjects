using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace Infrastructure.Infrastructure_Module
{
    public static class InfraModule
    {
        public static IServiceCollection InfraServices(this IServiceCollection service)
        {
            service.AddHttpClient();
            service.AddScoped<IWeatherHttpClient, WeatherHttpClient>();
            service.AddSingleton<IRequestStatisticRepository, RequestStatisticRepository>();
            return service;
        }
    }
}
