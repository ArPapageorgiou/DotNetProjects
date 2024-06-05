using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DIModule
    {
        public static IServiceCollection Services(this IServiceCollection services) 
        { 
            services.AddHttpClient();
            services.AddTransient<IWeatherHttpClient, WeatherHttpClient>();

            return services;
        }
    }
}
