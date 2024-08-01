using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Core__Basics.Models
{
    public class EmployeeProject
    {
        //Many-to-Many
        public int EmployeeId { get; set; } //Foreign key 
        public virtual Employee Employee { get; set; }//Reference navigation property to principal entity
        
        public int ProjectId { get; set; }//Foreign key 
        public virtual Project Project { get; set; }//Reference navigation property to principal entity
        
    }
}
