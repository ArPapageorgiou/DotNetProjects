using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<Transaction> transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Book>().HasKey(b => b.BookId);

            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Description).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Genre).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.TotalCopies).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.AvailableCopies).IsRequired();

            modelBuilder.Entity<Member>().HasKey(m => m.MemberId);
            
            modelBuilder.Entity<Member>().Property(m => m.FirstName).IsRequired();
            modelBuilder.Entity<Member>().Property(m => m.LastName).IsRequired();
            modelBuilder.Entity<Member>().Property(m => m.Phone).IsRequired();
            modelBuilder.Entity<Member>().Property(m => m.Email).IsRequired();

            modelBuilder.Entity<Transaction>().HasKey(t => t.TransactionId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Member)
                .WithMany(m => m.Transactions)
                .HasForeignKey(t => t.MemberId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Book)
                .WithMany(b => b.Transactions)
                .HasForeignKey(t => t.BookId);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.RentedAt)
                .HasDefaultValue(DateTime.Now);

            
                
        }
    }
}
