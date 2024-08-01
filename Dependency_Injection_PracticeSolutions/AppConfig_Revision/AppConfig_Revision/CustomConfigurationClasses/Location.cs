using System.Configuration;

namespace AppConfig_Revision.CustomConfigurationClasses
{
    public class Location : ConfigurationElement
    {
        [ConfigurationProperty("continent")]
        public string Continent 
        {
            get => this["continent"].ToString() ?? string.Empty;
            set => this["continent"] = value;
        }

        [ConfigurationProperty("country")]
        public string Country 
        {
            get => this["country"].ToString() ?? string.Empty;
            set => this["country"] = value;
        }
    }
}
