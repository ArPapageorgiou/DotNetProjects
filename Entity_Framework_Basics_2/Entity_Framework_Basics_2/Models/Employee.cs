namespace Entity_Framework_Basics_2.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }    
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public EmployeeDetails EmployeeDetails { get; set; }
        public int ManagerID { get; set; }
        public Manager Manager { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }    
    }
}
