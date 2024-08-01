using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dungeon_And_Dragons_ClassLibrary;
using Pen_And_Paper_ClassLibrary;
using ConsoleUI;

namespace Dependency_Injection_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddTransient<IDungeonMaster, DungeonMaster>();
                services.AddTransient<IDungeonMaster2, DungeonMaster2>();
                services.AddTransient<IDungeon, Dungeon>();
                services.AddService();
            }).Build();

            var app = host.Services.GetRequiredService<IDungeonMaster>();
            app.Play();
        }
    }
}
