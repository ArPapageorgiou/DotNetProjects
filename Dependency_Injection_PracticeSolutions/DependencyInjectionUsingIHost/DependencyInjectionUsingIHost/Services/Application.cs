using Microsoft.Extensions.Logging;
using ADifferentProject;
using ClassLibrary_ModuleExample.Services;

namespace DependencyInjectionUsingIHost.Services
{
    internal class Application : IApplication, IApplication2
    {
        private readonly ILogger<Application> _logger;
        private readonly IApplication2 _application2;
        private readonly IApplicationFromAnotherProject? _applicationFromAnotherProject;
        private readonly IBottleService _bottleService;
        private readonly ITableService _tableService;

        public Application(ILogger<Application> logger, IApplication2 application2, IApplicationFromAnotherProject? applicationFromAnotherProject, IBottleService bottleService, ITableService tableService)
        {
            _logger = logger;
            _application2 = application2;
            _applicationFromAnotherProject = applicationFromAnotherProject;
            _bottleService = bottleService;
            _tableService = tableService;
        }

        public void Run() 
        {
            _logger.LogInformation("Logging from the Application class!");
            Console.WriteLine("Hello, World from the Application class!");
            _application2?.Run();
            _applicationFromAnotherProject?.Run();
            _bottleService.GetBottle();
            _tableService?.GetTable();
        } 
    }
}
