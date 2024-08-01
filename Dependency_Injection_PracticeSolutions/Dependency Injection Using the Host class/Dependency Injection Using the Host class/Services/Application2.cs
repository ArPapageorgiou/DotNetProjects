using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection_Using_the_Host_class.Services
{
    public class Application2 : IApplication2
    {
        public void Run()
        {
            Console.WriteLine("Doom is the best game from Application class");
        }
    }
}
