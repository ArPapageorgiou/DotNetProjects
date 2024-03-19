using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Another_Project_ClassLibrary;
using Table_Bottle_ClassLibrary;
using ConsoleUI;

namespace DependencyInjection_Resolve_Dependencies_usingIHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder().ConfigureServices(services => 
            {
                services.AddTransient<IApplication, Application>();
                services.AddTransient<IApplication2, Application2>();
                services.AddTransient<IApplicationFromAnotherClass, ApplicationFromAnotherClass>();
                services.AddServices();
            }).Build();

            var app = host.Services.GetRequiredService<IApplication2>();
            app.Run();

            var app2 = host.Services.GetRequiredService<IApplicationFromAnotherClass>();
            app2.Run();

            var app3 = host.Services.GetRequiredService<IBottleService>();
            app3.Run();

            var app4 = host.Services.GetRequiredService<ITableService>();
            app4.Run(); 
        }
    }
}
