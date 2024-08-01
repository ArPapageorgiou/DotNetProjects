using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ApplicationModule
{
    public static class AppService
    {
        public static IServiceCollection AppServices(this IServiceCollection service) 
        {
            service.AddScoped<IApplication, Application>();
            return service;
        }
    }
}
