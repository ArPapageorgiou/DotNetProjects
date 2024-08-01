using Microsoft.Extensions.DependencyInjection;

namespace Table_Bottle_ClassLibrary
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
