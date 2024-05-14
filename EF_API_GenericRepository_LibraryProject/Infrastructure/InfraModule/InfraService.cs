using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.InfraModule
{
    public static class InfraService
    {
        public static IServiceCollection InfraServices(this IServiceCollection service) 
        {
            DataBaseConfiguration dataBaseConfiguration = (DataBaseConfiguration)ConfigurationManager.GetSection("DatabaseConfigurationSection");
            
            service.AddDbContext<AppDbContext>(options => options.UseSqlServer(dataBaseConfiguration.ConnectionString));
            return service;
        }
    }
}
