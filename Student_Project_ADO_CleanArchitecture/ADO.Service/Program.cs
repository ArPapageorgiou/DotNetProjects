using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ADO.Application.Services;
using ADO.Application.Interfaces;
using ADO.Infrastructure;

namespace ADO.Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AppServices();
                services.InfraServices();
            }).Build();

            var app = host.Services.GetRequiredService<IApplication>();
            app.BulkInsertTextRun();
        }
    }
}
