using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Data
{
    internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<RentalTransaction> rentalTransactions {get; set;}
    }
}
