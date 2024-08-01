using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Infrastructure.Data;
using Application.Interfaces;
using Infrastructure.Repositories;




namespace Infrastructure.InfrastructureModule
{
    public static class InfrastructureServices
    {

        public static IServiceCollection InfraService(this IServiceCollection service) 
        {
            DatabaseConfiguration dataBaseConfiguration = (DatabaseConfiguration)ConfigurationManager.GetSection("DatabaseConfigurationSection");
            service.AddDbContext<AppDbContext>(options => options.UseSqlServer(dataBaseConfiguration.ConnectionString));
            
            service.AddHttpClient();
            service.AddMemoryCache();
            service.AddScoped<IHttpClientRepository, HttpClientRepository>();
            service.AddScoped<ICacheAccess, CacheAccess>();
            service.AddScoped<IWeatherDataRepository, WeatherDataRepository>();
            service.AddSingleton(dataBaseConfiguration);

            
            return service;
        }
    }
}
