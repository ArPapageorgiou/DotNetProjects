using Entity_Framework_Core__Basics.Models;
using Microsoft.EntityFrameworkCore;
namespace Entity_Framework_Core__Basics.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Employee> _employees { get; set; }
        public DbSet<Manager> _managers { get; set; }
        private string _connectionString { get;}
        public AppDBContext()
        {
            _connectionString = "data source=DESKTOP-3BA0QHV; Initial Catalog=EmployeeManagement; integrated security=true";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
