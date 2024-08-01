using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Core__Basics.Models
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //one-to-one
        //Here we have a one-to-one relationship between Employee and EmployeeDetails
        //And then we have a reference navigation property to the principal entity - Employee-
        //We call Employee class the principal entity as that is the entity to which the foreign
        //key points to.
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } //reference navigation property.
                                               //This is essential for accessing related entities. 

    }
}
