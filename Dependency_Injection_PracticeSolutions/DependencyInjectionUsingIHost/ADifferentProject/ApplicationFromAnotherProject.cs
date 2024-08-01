using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADifferentProject
{
    public class ApplicationFromAnotherProject : IApplicationFromAnotherProject
    {
        public void Run()
        {
            Console.WriteLine("Run from a different project");
        }
    }
}
