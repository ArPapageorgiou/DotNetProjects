using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ADO.Application.Services;
using ADO.Application.Interfaces;
using ADO.Infrastructure;

using ADO_Student_Domain.Entities;


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


            var app = host.Services.GetRequiredService<IStudentRepository>();
            Student student1 = new Student
            {
                Id = 101,
                Name = "Argiris",
                Age = 35,
                IsCool = true,
            };
            app.UpdateStudentWithProcedure(student1);

        }
    }
}
