using Rock_paper_scissors_with_Dependency_Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_paper_scissors_with_Dependency_Injection
{
    internal class ComputerPlayer : IPlayer
    {
        public Choice GetChoice() 
        {
            Random rnd = new Random();

            Choice p2 = (Choice)rnd.Next(0, 3);
            Console.WriteLine("Player2 picked " + p2);
            return p2;
        }
    }
}
