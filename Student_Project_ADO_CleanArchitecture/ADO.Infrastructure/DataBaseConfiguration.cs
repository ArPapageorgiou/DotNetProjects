using System.Configuration;

namespace ADO.Infrastructure
{
    public class DataBaseConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("connectionString")]

        public string ConnectionString 
        {
            get => this["connectionString"].ToString() ?? string.Empty;
            set => this["connectionString"] = value;
        }
    }
}
