using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Config_test
{
    public class Queue : ConfigurationElement
    {
        [ConfigurationProperty("pass")]
        public string Pass 
        { 
            get => this["pass"].ToString() ?? string.Empty; 
            set => this["pass"] = value; 
        }

        [ConfigurationProperty("fire")]
        public string FIre 
        {
            get => this["fire"].ToString() ?? string.Empty;
            set => this["fire"] = value;
        }
    }
}
