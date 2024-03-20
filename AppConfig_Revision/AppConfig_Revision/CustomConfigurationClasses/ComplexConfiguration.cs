
﻿using System.Configuration;

namespace AppConfig_Revision.CustomConfigurationClasses
{
    public class ComplexConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("company", IsRequired = true, IsKey = true)]
        public string Company 
        { 
            get => this["company"].ToString() ?? string.Empty;
            set => this["company"] = value;
        }

        [ConfigurationProperty("size")]
        public string Size 
        {
            get => this["size"].ToString() ?? string.Empty;
            set => this["size"] = value;
        }

    }

    public class ComplexConfigurationCollection : ConfigurationElementCollection 
    {
        public new ComplexConfigurationElement this[string company] 
        {
            get => (ComplexConfigurationElement)BaseGet(company);
            set 
            {
                if (BaseGet(company) != null) 
                { 
                BaseRemove(company);
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
            return ((ComplexConfigurationElement)element).Company;
        }
    }

    public class ComplexConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("ComplexConfigurations")]
        [ConfigurationCollection(typeof(ComplexConfigurationCollection),
            AddItemName = "add")]

        public ComplexConfigurationCollection ConfigurationCollection
            => (ComplexConfigurationCollection)this["ComplexConfigurations"];

    }
}
