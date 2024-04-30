using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Domain.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Genre).IsRequired();
            builder.Property(b => b.Description).IsRequired();
            builder.Property(b => b.TotalCopies).IsRequired();
            builder.Property(b => b.AvailableCopies).IsRequired();
        }
    }
}
