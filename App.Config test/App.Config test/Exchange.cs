using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Config_test
{
    public class Exchange : ConfigurationElement
    {
        [ConfigurationProperty("roadnumber")]
        public int RoadNumber 
        { 
            get => Convert.ToInt32(this["roadnumber"]); 
            set => this["roadnumber"] = value; 
        }


        [ConfigurationProperty("room")]
        public int Room 
        {
            get => Convert.ToInt32(this["room"]);
        }
    }
}
