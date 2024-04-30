using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Configurations;

namespace Infrastructure.Data
{
    internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<RentalTransaction> rentalTransactions {get; set;}
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new RentalTransactionConfiguration());
        }
    }
}
