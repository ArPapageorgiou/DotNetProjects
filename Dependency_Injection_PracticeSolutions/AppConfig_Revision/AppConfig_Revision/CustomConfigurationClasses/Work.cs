using System.Configuration;

namespace AppConfig_Revision.CustomConfigurationClasses
{
    public class Work : ConfigurationElement
    {
        [ConfigurationProperty("field")]
        public string Field 
        {
            get => this["field"].ToString() ?? string.Empty; 
            set => this["field"] = value;
        }

        [ConfigurationProperty("salary")]
        public string Salary 
        { 
            get => this["salary"].ToString() ?? string.Empty;
            set => this["salary"] = value;
        }
    }
}
