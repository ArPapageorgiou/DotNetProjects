using Entity_Framework_Core__Basics.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Entity_Framework_Core__Basics.Data
{
    public class AppDBContext : DbContext
    {

        //Create a DBSet property for every new table 
        public DbSet<Project> Project { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        //Create a DBSet property for your connection string
        private string ConnectionString { get;}
        public AppDBContext()
        {
            ConnectionString = "data source=DESKTOP-3BA0QHV; Initial Catalog=EmployeeManagement; integrated security=SSPI;Trust Server Certificate=True";


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(ConnectionString);
        }

        //Many-To-Many    Fluent API
        //In the case of many to many relationship we need to override the OnModelCreating method in order
        //configure the relationship between the Employee, Project, and EmployeeProject entities. We do this
        //using Fluent API and is implemented using method chaining.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //For example we can use Fluent API to configure the primary key of a table like this:
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);//or we can use data annotations

            //specify entity(Employee)-which property?(e => e.FirstName)-what do you want to do with it?(IsRequired())
            modelBuilder.Entity<Employee>().Property(e => e.FirstName).IsRequired();//Again we can achieve
                                                                                    //the same result with
                                                                                    //data annotations. Look
                                                                                    //at the Employee class.
            
            //Now lets Configure the relationship between the Employee, Project, and EmployeeProject entities
            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.ProjectId, ep.EmployeeId }); 
            //Sets the primary key for the EmployeeProject table. 

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);
            //Specifies that each EmployeeProject is associated with one Employee, and each Employee can
            //have many EmployeeProjects.
            //Says that the EmployeeId column in EmployeeProject holds the foreign key to link with the
            //EmployeeId primary key in the Employee table.

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);
            //Specifies that each EmployeeProject is associated with one Project, and each Project can have
            //many EmployeeProjects.
            //Indicates that the ProjectId column in EmployeeProject holds the foreign key to link with the
            //ProjectId primary key in the Project table.

        }
    }
}
