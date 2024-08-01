namespace Entity_Framework_Basics_2.Models
{
    public class Project
    {
        public int EmployeeProjectId { get; set; }
        public string Title { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
