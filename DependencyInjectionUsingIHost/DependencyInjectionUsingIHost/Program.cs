using ADifferentProject;
using ClassLibrary_ModuleExample;
using DependencyInjectionUsingIHost.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace DependencyInjectionUsingIHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder().ConfigureServices(
                services =>
                {
                    services.AddTransient<IApplication2, Application2>();
                    services.AddTransient<IApplication, Application>();
                    services.AddTransient<IApplicationFromAnotherProject, ApplicationFromAnotherProject>();
                    services.AddServices();
                })
                .Build();

            
            var app = host.Services.GetRequiredService<IApplication>();
            app.Run();
                
                
        }
    }
}
