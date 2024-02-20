using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_paper_scissors_with_Dependency_Injection
{
    public class HumanPlayer : IPlayer
    {
        public Choice GetChoice()
        {
            Choice p1;

            do
            {
                Console.WriteLine("Please enter your Choice: (R)ock, (P)aper or (S)cissors");
                string input = Console.ReadLine().ToUpper();

                if (input == "R")
                {
                    p1 = Choice.Rock;
                    break;
                }

                if (input == "P")
                {
                    p1 = Choice.Paper;
                    break;
                }

                if (input == "S")
                {
                    p1 = Choice.Scissors;
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid Choice. Please try again.");
                }

            } while (true);
            return p1;
        }
    }
}
