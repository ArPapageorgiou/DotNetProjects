using System.Configuration;

namespace AppConfig_Revision.CustomConfigurationClasses
{
    internal class SimpleConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("connectionString")]
        public string ConnectionString 
        {
            get => this["connectionString"].ToString() ?? string.Empty;
            set => this["connectionString"] = value;
        }

        [ConfigurationProperty("pageSize")]
        public int PageSize 
        {
            get => Convert.ToInt32(this["pageSize"]);
            set => this["pageSize"] = value;

        }
    }
}
