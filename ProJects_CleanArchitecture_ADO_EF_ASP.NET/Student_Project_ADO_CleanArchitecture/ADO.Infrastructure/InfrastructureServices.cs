using ADO.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace ADO.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection InfraServices(this IServiceCollection services) 
        {
            DataBaseConfiguration dataBaseConfiguration = (DataBaseConfiguration)ConfigurationManager.GetSection("DataBaseConfigurationSection");
            services.AddSingleton<IStudentRepository, Repositories.StudentRepository>();
            services.AddSingleton(dataBaseConfiguration);

            return services;
        }
    }
}
