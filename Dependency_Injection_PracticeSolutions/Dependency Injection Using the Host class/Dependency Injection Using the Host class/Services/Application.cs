using AnotherProject;
using BottleAndTableServicesModule.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection_Using_the_Host_class.Services
{
    internal class Application : IApplication, IApplication2
    {
        private readonly ILogger<Application> _logger;
        private readonly IApplication2 _application2;
        private readonly IBottleService _bottleService;
        private readonly ITableService _tableService;
        private readonly IAnotherClass _anotherclass;

       public Application(ILogger<Application> logger, IApplication2 application2, IBottleService bottleService, ITableService tableService, IAnotherClass anotherclass)
        {
            _logger = logger;
            _application2 = application2;
            _bottleService = bottleService;
            _tableService = tableService;
            _anotherclass = anotherclass;
        }

        public void Run() 
        {
            _logger.LogInformation("Logging from the application class");
            Console.WriteLine("Hello world from the application class");
            _application2.Run();
            _bottleService.Run();
            _tableService.Run();
            _anotherclass.Run();
        }
    }
}
