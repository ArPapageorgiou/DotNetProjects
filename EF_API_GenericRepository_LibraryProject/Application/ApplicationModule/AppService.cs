using Microsoft.Extensions.DependencyInjection;

namespace Application.ApplicationModule
{
    public static class AppService
    {
        public static IServiceCollection AppServices(this IServiceCollection service) 
        {
            return service;
        }
    }
}
