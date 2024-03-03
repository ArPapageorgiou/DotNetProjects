using AnotherProject;
using BottleAndTableServicesModule;
using Dependency_Injection_Using_the_Host_class.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Dependency_Injection_Using_the_Host_class
{
    public class Program
    {
        static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder().ConfigureServices(
                services =>
                {
                    services.AddTransient<IApplication, Application>();
                    services.AddTransient<IApplication2, Application2>();
                    services.AddTransient<IAnotherClass, AnotherClass>();
                    services.AddServices();
                }).Build();

            var app = host.Services.GetRequiredService<IApplication>();
            app.Run();

        }
    }
}
