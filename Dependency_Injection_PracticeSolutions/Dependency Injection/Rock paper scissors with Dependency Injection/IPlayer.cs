using Rock_paper_scissors_with_Dependency_Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rock_paper_scissors_with_Dependency_Injection
{
    public interface IPlayer
    {
        public Choice GetChoice();

    }
}
