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
        public static IServiceCollection InfraServices(this IServiceCollection service) 
        {
            DatabaseConfiguration dataBaseConfiguration = (DatabaseConfiguration)ConfigurationManager.GetSection("DatabaseConfigurationSection");

            service.AddDbContext<AppDbContext>(options => options.UseSqlServer(dataBaseConfiguration.ConnectionString));
            service.AddHttpClient();
            service.AddScoped<IHttpClientRepository, HttpClientRepository>();
            
            return service;
        }
    }
}
