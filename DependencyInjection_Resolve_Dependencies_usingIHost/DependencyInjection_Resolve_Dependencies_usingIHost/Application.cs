using Another_Project_ClassLibrary;
using Table_Bottle_ClassLibrary;

namespace ConsoleUI
{
    internal class Application : IApplication, IApplication2
    {

        private readonly IApplication2 _application2;
        private readonly IApplicationFromAnotherClass _applicationFromAnotherClass;
        private readonly ITableService _tableService;
        private readonly IBottleService _bottleService;


        public Application(

            IApplication2 application2,
            IApplicationFromAnotherClass applicationFromAnotherClass,
            ITableService tableService,
            IBottleService bottleService)
        { 

            _application2 = application2;
            _applicationFromAnotherClass = applicationFromAnotherClass;
            _tableService = tableService;
            _bottleService = bottleService;
        }

        public void Run() 
        {

            _application2.Run();
            _applicationFromAnotherClass.Run();
            _bottleService.Run();
            _tableService.Run();
        }
    }
}
