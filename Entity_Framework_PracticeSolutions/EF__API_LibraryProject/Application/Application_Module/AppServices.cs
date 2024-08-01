using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Application.Interfaces;

namespace Application.Application_Module

{
    public static class AppServices
    {
        public static IServiceCollection AppService(this IServiceCollection services) 
        {
            services.AddScoped<IApplication, Application>();
            return services;
        }
    }
}
