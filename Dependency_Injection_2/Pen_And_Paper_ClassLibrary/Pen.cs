using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pen_And_Paper_ClassLibrary
{
    public class Pen : IPen
    {
        public void Play() { Console.WriteLine("Write down your skill points!"); }
    }
}
