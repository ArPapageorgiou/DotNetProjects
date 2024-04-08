namespace Entity_Framework_Core__Basics.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string MngFirstName { get; set; }
        public string MngLastName { get; set; }

        //Since there is a one-to-many relationship with Employee we have to use this collection navigation
        //property to represent the Employees managed by the manager. ICollection is used to to represent a
        //collection navigation property in a one-to-many relationship. In essense the bellow setup means this
        //manager can have more than one employees.
        public ICollection<Employee> Employees { get; set; }

    }
}
