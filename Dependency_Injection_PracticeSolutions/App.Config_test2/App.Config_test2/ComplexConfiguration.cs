using System.Configuration;

namespace App.Config_test2
{
    public class ComplexConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true, IsKey = true)]

        public int Id
        {
            get => Convert.ToInt32(this["id"]);
            set => this["id"] = value;
        }

        [ConfigurationProperty("name")]

        public string Name
        {
            get => this["name"].ToString() ?? string.Empty;
            set => this["name"] = value;
        }
    }

    public class ComplexConfigurationCollection : ConfigurationElementCollection
    {
        public new ComplexConfigurationElement this[string id] 
        { 
            get=> (ComplexConfigurationElement)BaseGet(id);
            set 
            {
                if (BaseGet(id) != null)
                {
                    BaseRemove(id);
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
            return ((ComplexConfigurationElement)element).Id;
        }

    }

    public class ComplexConfiguration : ConfigurationSection 
    {
        [ConfigurationProperty("ComplexConfigurations")]
        [ConfigurationCollection(typeof(ComplexConfigurationCollection), AddItemName = "add")]
        public ComplexConfigurationCollection ConfigurationCollection
            => (ComplexConfigurationCollection)this["ComplexConfigurations"];
    }
       
}

    
    
   

