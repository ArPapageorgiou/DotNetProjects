using BottleAndTableServicesModule.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BottleAndTableServicesModule
{
    public static class ServicesModule
    {
        public static IServiceCollection AddServices(this IServiceCollection service) 
        { 
            service.AddTransient<IBottleService, BottleService>();
            service.AddTransient<ITableService, TableService>();
            return service;
        }
    }
}
