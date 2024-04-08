using Entity_Framework_Core__Basics.Models;
using Microsoft.EntityFrameworkCore;
namespace Entity_Framework_Core__Basics.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        private string ConnectionString { get;}
        public AppDBContext()
        {
            ConnectionString = "data source=DESKTOP-3BA0QHV; Initial Catalog=EmployeeManagement; integrated security=SSPI;Trust Server Certificate=True";

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
