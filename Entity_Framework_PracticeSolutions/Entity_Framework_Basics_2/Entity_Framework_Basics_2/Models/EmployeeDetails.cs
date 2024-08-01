using System.ComponentModel.DataAnnotations;

namespace Entity_Framework_Basics_2.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int DetailsId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
