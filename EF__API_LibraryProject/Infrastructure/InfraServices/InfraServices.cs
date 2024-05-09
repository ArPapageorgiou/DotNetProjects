using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Infrastructure.InfraServices
{
    public static class Infrastructure_Services
    {
        public static IServiceCollection InfraServices(this IServiceCollection services) 
        {
            DatabaseConfiguration databaseConfiguration = (DatabaseConfiguration)ConfigurationManager.GetSection("DataBaseConfigurationSection");

            var connectionString = databaseConfiguration.ConnectionString;

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(databaseConfiguration.ConnectionString));

            services.AddScoped<IBookRepository, Repositories.BookRepository>();
            services.AddScoped<IMemberRepository, Repositories.MemberRepository>();
            services.AddScoped<IRentalTransaction, Repositories.RentalTransactionRepository>();
            
            
            return services;
        }
    }
}
