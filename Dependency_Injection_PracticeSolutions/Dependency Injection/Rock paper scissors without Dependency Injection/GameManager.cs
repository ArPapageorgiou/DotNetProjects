using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_paper_scissors_with_Dependency_Injection
{
    public class GameManager
    {
        public roundResult PlayRound()
        {
            Random rnd = new Random();

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

            Choice p2 = (Choice)rnd.Next(0, 3);
            Console.WriteLine("Player2 Picked " + p2.ToString());

            if (p1 == p2) 
            {
                return roundResult.Draw;
            }
            if (p1 == Choice.Rock && p2 == Choice.Scissors ||
                p1 == Choice.Scissors && p2 == Choice.Paper ||
                p1 == Choice.Paper && p2 == Choice.Rock)
            {
                return roundResult.Player1Win;
            }
            else 
            {
                return roundResult.Player2Win;
            }
        }   
    }

    public enum Choice 
    { 
    Rock,
    Paper,
    Scissors
    }

    public enum roundResult 
    { 
    Player1Win,
    Player2Win,
    Draw
    }
}
