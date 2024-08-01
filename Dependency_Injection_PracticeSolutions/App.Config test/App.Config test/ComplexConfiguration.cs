using System.Configuration;

namespace App.Config_test
{
    public class ComplexConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name 
        {
            get => this["name"].ToString() ?? string.Empty;
            set => this["name"] = value; 
        }

        [ConfigurationProperty("id")]
        public int Id 
        {
            get => Convert.ToInt32(this["id"]);
            set => this["id"] = value;
        }
    }

    public class ComplexConfigurationCollection : ConfigurationElementCollection 
    { 
    public new ComplexConfigurationElement this[string name]
        {
            get => (ComplexConfigurationElement)BaseGet(name);
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
        return new ComplexConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element) 
        {
            return ((ComplexConfigurationElement)element).Name;
        }
    }

    public class ComplexConfiguration : ConfigurationSection 
    {
        [ConfigurationProperty("ComplexConfigurations")]
        [ConfigurationCollection(typeof(ComplexConfigurationCollection), AddItemName = "add")]
        public ComplexConfigurationCollection ConfigurationCollections =>
            (ComplexConfigurationCollection)this["ComplexConfigurations"];
    }
}
