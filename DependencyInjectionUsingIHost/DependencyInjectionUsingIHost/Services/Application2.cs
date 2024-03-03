using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionUsingIHost.Services
{
    public class Application2 : IApplication2
    {
        public void Run()
        {
            Console.WriteLine("Hello from Application2!");
        }
    }
}
