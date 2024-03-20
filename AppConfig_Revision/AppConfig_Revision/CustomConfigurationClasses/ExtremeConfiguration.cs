using System.Configuration;

namespace AppConfig_Revision.CustomConfigurationClasses
{
    public class ExtremeConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name 
        {
            get => this["name"].ToString() ?? string.Empty;
            set => this["name"] = value; 
        }

        [ConfigurationProperty("id")]
        public string Id 
        {
            get => this["id"].ToString() ?? string.Empty; 
            set => this["id"] = value;
        }

        [ConfigurationProperty("Location")]
        public Location LocationProperty 
        {
            get => (Location)this["Location"]; 
            set => this["Location"] = value;
        }

        [ConfigurationProperty("Work")]
        public Work WorkProperty 
        {
            get => (Work)this["Work"];
            set => this["Work"] = value;
        }
    }

    public class ExtremeConfigurationCollection : ConfigurationElementCollection 
    {
        public new ExtremeConfigurationElement this[string name]
        {
            get => (ExtremeConfigurationElement)BaseGet(name);

            set 
            {
                if (BaseGet(name) != null) 
                {
                    BaseRemove(name);
                }
                BaseAdd(value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ExtremeConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ExtremeConfigurationElement)element).Name;
        }
    }

    public class ExtremeConfiguration : ConfigurationSection 
    {
        [ConfigurationProperty("ExtremeConfigurations")]
        [ConfigurationCollection(typeof(ExtremeConfigurationCollection), AddItemName = "add")]

        public ExtremeConfigurationCollection ExtremeConfigurations => (ExtremeConfigurationCollection)this["ExtremeConfigurations"];
    }
    
}
