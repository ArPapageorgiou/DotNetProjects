using System.Configuration;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace App.Config_test
{
    
    internal class Program
    {
        static void Main(string[] args) 
        {
            ExtremeConfiguration? extremeConfiguration = ConfigurationManager.GetSection("ExtremeConfigurationSection") as ExtremeConfiguration;
            if (extremeConfiguration != null && extremeConfiguration.ExtremeConfigurations != null)
            {
                foreach (ExtremeConfigurationElement item in extremeConfiguration.ExtremeConfigurations)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.ID);
                    Console.WriteLine(item.Exchange.RoadNumber);
                    Console.WriteLine(item.Exchange.Room);
                    Console.WriteLine(item.Queue.Pass);
                    Console.WriteLine(item.Queue.FIre);
                }
            }
            else
            {
                Console.WriteLine("Failed to retrieve custom configuration section.");
            }


            //ComplexConfiguration? complexConfiguration = ConfigurationManager.GetSection("ComplexConfigurationSection") as ComplexConfiguration;
            //if (complexConfiguration != null)
            //{
            //    foreach (ComplexConfigurationElement item in complexConfiguration.ConfigurationCollections)
            //    {
            //        Console.WriteLine(item.Name);
            //        Console.WriteLine(item.Id);
            //    }
            //}

            //SimpleConfiguration? simpleConfiguration = ConfigurationManager.GetSection("SimpleConfigurationSection") as SimpleConfiguration;
            //if (simpleConfiguration != null)
            //{
            //    Console.WriteLine(simpleConfiguration.ConnectionString);
            //    Console.WriteLine(simpleConfiguration.PageSize);

            //}
        }
    }
}
