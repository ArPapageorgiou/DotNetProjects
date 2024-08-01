namespace ExtendedMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            "this is printed by an extended method".PrintToConsole();
            string demo = "this is also printed by an extended method";
            demo.PrintToConsole();

            ISimpleLoggger logger = new SimpleLoggger();
            logger.Log(" this is an error", "Error");
            logger.LogError(" this is an error");
        }
    }


}
