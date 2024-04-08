namespace Entity_Framework_Core__Basics.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }   
        public long EmpSalary { get; set; }
        public EmployeeDetails EmployeeDetails { get; set; }
    }
}
