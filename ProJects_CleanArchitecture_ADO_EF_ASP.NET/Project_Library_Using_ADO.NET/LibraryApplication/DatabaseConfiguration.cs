using System.Configuration;

namespace Library_Infrastructure
{
    public class DatabaseConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("connectionString")]

        public string ConnectionString 
        {
            get => this["connectionString"].ToString() ?? string.Empty;
            set=> this["connectionString"] = value;
        }
    }
}
