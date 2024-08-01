using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Config_test2
{
    public class Adress :ConfigurationElement
    {
        [ConfigurationProperty("streetnumber")]
        public int StreetNumber 
        {
            get=> Convert.ToInt32((this["streetnumber"].ToString()));
            set => this["streetnumber"] = value; 
        }

        [ConfigurationProperty("roomnumber")]
        public int RoomNumber
        {
            get => Convert.ToInt32((this["roomnumber"].ToString()));
            set => this["roomnumber"] = value;
        }
    }
}
