using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Config_test2
{
    public class ExtremeConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("postalcode", IsRequired = true, IsKey = true)]
        public int PostalCode 
        { 
            get=>Convert.ToInt32(this["postalcode"].ToString()); 
            set=>this["postalcode"] = value;
        }

        [ConfigurationProperty("city")]
        public string City 
        { 
            get=> this["city"].ToString() ?? string.Empty; 
            set=> this["city"] = value;
        }

        [ConfigurationProperty("adress")]
        public Adress Adress 
        { 
            get=>(Adress)this["adress"]; 
            set=> this["adress"] = value;    
        }  
    }

    public class ExtremeConfigurationCollection : ConfigurationElementCollection 
    { 
    public ExtremeConfigurationElement this[int PostalCode] 
        {
            get => (ExtremeConfigurationElement)BaseGet(PostalCode);
            set 
            {
                if (value != null) 
                {
                    BaseRemove(PostalCode);
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
            return ((ExtremeConfigurationElement)element).PostalCode;
        }
    }

    public class ExtremeConfiguration : ConfigurationSection 
    {
        [ConfigurationProperty("ExtremeConfigurations")]
        [ConfigurationCollection(typeof(ExtremeConfigurationCollection), AddItemName = "add")]

        public ExtremeConfigurationCollection ExtremeConfigurations
            => (ExtremeConfigurationCollection)this["ExtremeConfigurations"];
    }
}
