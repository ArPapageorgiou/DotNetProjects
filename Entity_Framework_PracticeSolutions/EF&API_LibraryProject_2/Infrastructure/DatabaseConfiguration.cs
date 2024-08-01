using System.Configuration;


namespace Infrastructure
{
    internal class DatabaseConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("connectionString")]
        public string ConnectionString 
        {
            get => this["connectionString"].ToString() ?? string.Empty;
            set => this["connectionString"] = value;
        }
    }
}
