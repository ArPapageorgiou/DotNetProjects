using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Domain.Models;

namespace Infrastructure.InfraServices
{
    public static class Infrastructure_Services
    {
        public static IServiceCollection InfraServices(this IServiceCollection services) 
        {
            DatabaseConfiguration databaseConfiguration = (DatabaseConfiguration)ConfigurationManager.GetSection("DataBaseConfigurationSection");
            
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(databaseConfiguration.ConnectionString));
            services.AddScoped<IBook, Book>
            
            return services;
        }
    }
}
