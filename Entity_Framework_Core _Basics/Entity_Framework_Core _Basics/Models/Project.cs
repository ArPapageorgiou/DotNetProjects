using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entity_Framework_Core__Basics.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        //ICollection<T> is a type used to represent the "many" side of a relationship and it provides us
        //with ways to interact with related entities and their properties. It provides methods to interact
        //with related entities, such as adding, removing, or accessing them. Once you have access to the
        //related entities through the collection navigation property (ICollection<T>), you can easily
        //access their properties and perform operations.
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } //Collection navigation property
    }
}
