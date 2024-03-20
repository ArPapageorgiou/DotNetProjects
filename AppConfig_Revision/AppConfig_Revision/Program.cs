using AppConfig_Revision.CustomConfigurationClasses;
using System.Configuration;

namespace AppConfig_Revision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleConfiguration? simpleConfiguration = ConfigurationManager.GetSection("SimpleConfigurationSection") as SimpleConfiguration;

            if (simpleConfiguration != null)
            {
                Console.WriteLine(simpleConfiguration.ConnectionString);
                Console.WriteLine(simpleConfiguration.PageSize);

            }

            ComplexConfiguration? complexConfiguration = ConfigurationManager.GetSection("ComplexConfigurationSection") as ComplexConfiguration;
            if (complexConfiguration != null)
            {
                foreach (ComplexConfigurationElement item in complexConfiguration.ConfigurationCollection)
                {
                    Console.WriteLine(item.Company);
                    Console.WriteLine(item.Size);
                }
            }

            ExtremeConfiguration? extremeConfiguration = ConfigurationManager.GetSection("ExtremeConfigurationSection") as ExtremeConfiguration;

            if (extremeConfiguration != null && extremeConfiguration.ExtremeConfigurations != null) 
            {
                foreach (ExtremeConfigurationElement item in extremeConfiguration.ExtremeConfigurations) 
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.LocationProperty.Continent);
                    Console.WriteLine(item.LocationProperty.Country);
                    Console.WriteLine(item.WorkProperty.Field);
                    Console.WriteLine(item.WorkProperty.Salary);
                }
            }

        }
    }
}
