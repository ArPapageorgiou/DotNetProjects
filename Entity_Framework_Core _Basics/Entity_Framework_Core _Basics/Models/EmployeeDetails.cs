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

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
