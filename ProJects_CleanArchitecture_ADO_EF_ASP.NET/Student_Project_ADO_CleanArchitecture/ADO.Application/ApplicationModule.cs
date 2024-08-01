using ADO.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ADO.Application.Services
{
    public static class ApplicationModule
    {
        public static IServiceCollection AppServices(this IServiceCollection services)
        {
            services.AddSingleton<IApplication, Services.Application>();
            return services;
        }
    }
}
