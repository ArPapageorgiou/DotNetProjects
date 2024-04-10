namespace Entity_Framework_Basics_2.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string MngFirstName { get; set; }
        public string MngLastName { get; set;}
        public ICollection<Employee> Employees { get; set;}


    }
}
