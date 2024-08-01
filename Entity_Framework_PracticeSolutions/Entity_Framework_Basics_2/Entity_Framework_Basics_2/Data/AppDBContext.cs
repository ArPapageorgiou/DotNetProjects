using Microsoft.EntityFrameworkCore;
using Entity_Framework_Basics_2.Models;

namespace Entity_Framework_Basics_2.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }    
        public string ConnectionString { get;}

        public AppDBContext()
        {
            ConnectionString = "data source=DESKTOP-3BA0QHV; Initial catalog EmployeeManagement; Integrated security=SSPI; Trust Server Certificate=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>().HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(p => p.ProjectId);
        }
    }
}
