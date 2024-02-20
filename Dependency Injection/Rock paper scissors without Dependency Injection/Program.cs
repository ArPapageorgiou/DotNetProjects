namespace Rock_paper_scissors_with_Dependency_Injection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();

            do
            {
                roundResult result = gm.PlayRound();

                if (result == roundResult.Player1Win)
                {
                    Console.WriteLine("Player1 wins!");
                }
                else if (result == roundResult.Player2Win)
                {
                    Console.WriteLine("Player2 wins");
                }
                else
                {
                    Console.WriteLine("It's a draw!");
                }
                Console.WriteLine("Let's Play again: (Y)ES or (N)O");
                
             }while (Console.ReadLine().ToUpper() == "Y");
            
        }
    }
}
