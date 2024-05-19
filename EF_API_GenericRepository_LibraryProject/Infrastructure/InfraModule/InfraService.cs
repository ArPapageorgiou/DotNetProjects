using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.InfraModule
{
    public static class InfraService
    {
        public static IServiceCollection InfraServices(this IServiceCollection service) 
        {
            DataBaseConfiguration dataBaseConfiguration = (DataBaseConfiguration)ConfigurationManager.GetSection("DatabaseConfigurationSection");
            
            service.AddDbContext<AppDbContext>(options => options.UseSqlServer(dataBaseConfiguration.ConnectionString));
            service.AddScoped<IBookRepository, BookRepository>();
            service.AddScoped<IMemberRepository, MemberRepository>();
            service.AddScoped<ITransactionRepository, TransactionRepository>();
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return service;
        }
    }
}
