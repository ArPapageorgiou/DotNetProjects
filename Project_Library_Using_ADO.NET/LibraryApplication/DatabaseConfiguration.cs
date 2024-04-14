using System.Configuration;

namespace Library_Infrastructure
{
    public class DatabaseConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("connectionstring")]

        public string ConnectionString 
        {
            get => this["connectionstring"].ToString() ?? string.Empty;
            set=> this["connectionstring"] = value;
        }
    }
}
