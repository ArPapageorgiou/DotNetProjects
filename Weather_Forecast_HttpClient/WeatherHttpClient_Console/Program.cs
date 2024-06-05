using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application;

namespace WeatherHttpClient_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices(
                services => 
                { 
                    services.Services(); 
                })
                .Build();

            var app = host.Services.GetRequiredService<IWeatherHttpClient>();
            app.GetWeatherData().GetAwaiter().GetResult();
        }
    }
}
