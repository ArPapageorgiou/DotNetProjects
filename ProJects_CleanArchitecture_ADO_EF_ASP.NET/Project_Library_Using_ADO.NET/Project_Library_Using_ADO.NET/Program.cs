using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Library_Application.Interfaces;
using Library_Application.Services;
using Library_Infrastructure;
using Library_Application;
using Library_Services;

namespace Project_Library_Using_ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) => 
            {   services.AppServices();
                services.infraServices();
            }).Build();

            var app = host.Services.GetRequiredService<IApplication>();
            var ui = new UserInterface(app);
            ui.Menu();
            
        }
    }
}
