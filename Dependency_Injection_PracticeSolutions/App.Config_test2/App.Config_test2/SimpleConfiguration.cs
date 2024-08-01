using System.Configuration;

namespace App.Config_test2
{
    internal class SimpleConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("connectionstring")]
        public string ConnectionString
        {
            get => this["connectionstring"].ToString() ?? string.Empty;
            set => this["connectionstring"] = value;
        }

        [ConfigurationProperty("commandstring")]
        public string CommandString 
        {
            get => this["commandstring"].ToString() ?? string.Empty;
            set => this["commandstring"] = value;
        }
    }
}
