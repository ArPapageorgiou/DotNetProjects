using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pen_And_Paper_ClassLibrary
{
    public class Paper : IPaper
    {
        public void Play() { Console.WriteLine("You have one unused skill: Second Wind"); }
    }
}
