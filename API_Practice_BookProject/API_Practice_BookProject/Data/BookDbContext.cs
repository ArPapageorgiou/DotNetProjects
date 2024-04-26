using API_Practice_BookProject.Models;
using Microsoft.EntityFrameworkCore;


namespace API_Practice_BookProject.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
                
        }

        public DbSet<Book> books { get; set; }
    }
}
