using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace App.Config_test
{
    public class SimpleConfiguration : ConfigurationSection
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
            get => Convert.ToInt32(this["pageSize"].ToString());
            set => this["pageSize"] = value;
        
        
        }
    }
}
