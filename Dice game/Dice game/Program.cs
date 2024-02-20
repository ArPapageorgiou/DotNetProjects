using System;

namespace Dice_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let the dice roll!");
            Console.WriteLine("Press ENTER to roll your dice!");
            Console.ReadLine();

            turns();

            Console.WriteLine("Thank you for playing with skynet! Have a nice day!");
           

        }

        static int aiscore = 0;
        static int playerscore = 0;

        static int generateRandomnumber()
        {
            Random dice = new Random();
            return dice.Next(1, 7);
        }

        static void turns()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("||\\\\  ||  //  /_\\\\");
                Console.WriteLine("||//  ||  \\\\  \\\\__");

                int airoll = generateRandomnumber();
                int playerroll = generateRandomnumber();

                Console.WriteLine("The machines are generating a random integer");
                Console.WriteLine("AI rolled " + airoll);

                Console.WriteLine("You roll your dice...");
                System.Threading.Thread.Sleep(1500);

                Console.WriteLine("You rolled " + playerroll);
                Console.ReadLine() ;

                if (airoll > playerroll)
                {
                    aiscore++;

                    Console.WriteLine("AI wins this round!");
                    

                }
                else if (airoll < playerroll)
                {
                    playerscore++;

                    Console.WriteLine("You win this round");
                    
                }
                else 
                { 
                Console.WriteLine("It's a draw! The strongest player takes the prize!");
                    Console.ReadLine();

                    if (aiscore < playerscore)
                    {
                        Console.WriteLine("Go humans!");
                        playerscore++;
                        
                    }
                    else if (aiscore > playerscore) 
                    {
                        Console.WriteLine("The AI always dominates");
                        aiscore++;
                        
                    }
                    else 
                    { 
                        Console.WriteLine("The prize stays in the house!");
                        
                    }
                }
                scoreboard();
                Console.Clear();


                static void scoreboard()
                {
                    Console.WriteLine("SCORE:");
                    Console.WriteLine("AI : " + aiscore);
                    Console.WriteLine("Player : " + playerscore);
                    Console.ReadLine();
                }
            }

        }
       

    }
}
