using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ApplicationModule
{
    public static class AppServices
    {
        public static IServiceCollection AppService(this IServiceCollection service) 
        {
            service.AddScoped<IWeatherDataService, WeatherDataService>();
            service.AddHostedService<WeatherUpdateService>();
            return service;
        }
    }
}
