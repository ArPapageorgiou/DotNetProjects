using Microsoft.Extensions.DependencyInjection;
using ClassLibrary_ModuleExample.Services;
namespace ClassLibrary_ModuleExample
{
    public static class ServicesModule
    {
       public static IServiceCollection AddServices(this IServiceCollection services) 
        { 
            services.AddTransient<IBottleService, BottleService>();
            services.AddTransient<ITableService, TableService>();

            return services;
        }
    }
}
