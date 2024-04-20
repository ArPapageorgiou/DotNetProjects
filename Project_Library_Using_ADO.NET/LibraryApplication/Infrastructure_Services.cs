using Library_Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Library_Infrastructure
{
    public static class Infrastructure_Services
    {
        public static IServiceCollection infraServices(this IServiceCollection services) 
        {
            DatabaseConfiguration databaseConfiguration = (DatabaseConfiguration)ConfigurationManager.GetSection("DataBaseConfigurationSection");
            services.AddSingleton<IBooksRepository, Repositories.BooksRepository> ();
            services.AddSingleton<IMembersRepository, Repositories.MembersRepository>();
            services.AddSingleton<ITransactionsRepository, Repositories.TrasnsactionsRepository>();
            services.AddSingleton(databaseConfiguration);
            return services;
        }
    }
}
