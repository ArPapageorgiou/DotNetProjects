using Microsoft.Extensions.DependencyInjection;

namespace Pen_And_Paper_ClassLibrary
{
    public static class TableTop
    {
        public static IServiceCollection AddService(this IServiceCollection services) 
        { 
            services.AddTransient<IPaper, Paper>();
            services.AddTransient<IPen, Pen>();

            return services;
        }
    }
}
