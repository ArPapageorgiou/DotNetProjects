using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Configurations;


namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<RentalTransaction> RentalTransactions {get; set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new RentalTransactionConfiguration());



            modelBuilder.Entity<RentalTransaction>()
                .Property(e => e.RentedAt)
                .HasDefaultValue(DateTime.Now);

        }
    }
}
