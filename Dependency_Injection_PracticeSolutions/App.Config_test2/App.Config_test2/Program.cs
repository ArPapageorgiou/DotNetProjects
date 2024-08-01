using System.Configuration;
using System.IO.Pipes;

namespace App.Config_test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleConfiguration? simpleConfiguration = ConfigurationManager.GetSection("SimpleConfigurationSection") as SimpleConfiguration;
            if (simpleConfiguration != null)
            {
                Console.WriteLine(simpleConfiguration.ConnectionString);
                Console.WriteLine(simpleConfiguration.CommandString);
            }

            ComplexConfiguration? complexConfiguration = ConfigurationManager.GetSection("ComplexConfigurationSection") as ComplexConfiguration;
            if (complexConfiguration != null) 
            {
                foreach (ComplexConfigurationElement item in complexConfiguration.ConfigurationCollection) 
                { 
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                }

            }

            ExtremeConfiguration? extremeConfiguration = ConfigurationManager.GetSection("ExtremeConfigurationSection") as ExtremeConfiguration;
            if (extremeConfiguration != null && extremeConfiguration.ExtremeConfigurations != null) 
            {
                foreach (ExtremeConfigurationElement item in extremeConfiguration.ExtremeConfigurations) 
                {
                    Console.WriteLine(item.PostalCode);
                    Console.WriteLine(item.City);
                    Console.WriteLine(item.Adress.StreetNumber);
                    Console.WriteLine(item.Adress.RoomNumber);
                }
            }

        }
    }
}
