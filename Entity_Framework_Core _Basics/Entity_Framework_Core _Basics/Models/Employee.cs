namespace Entity_Framework_Core__Basics.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }   
        public long EmpSalary { get; set; }

        //One-to-one
        //Reference Navigation property to dependent entity - Employee Details
        //We call Employee Details the dependant entity as it holds the foreign key.
        public EmployeeDetails EmployeeDetails { get; set; }

        //One-to-many
        //the bellow setup means that each employee can have onnly one manager. You can see how the setup
        //on the employee side looks a lot like the one-to-one relationship from EmployeeDetails side.
        //Of course the setup from the manager class side is different.
        public int ManagerId { get; set; } //Foreign Key property
        public Manager Manager { get; set; } //Navigation Property to represent the manager

        public ICollection<EmployeeProject> EmployeeProjects { get; set; } //Collection navigation property
    }
}
