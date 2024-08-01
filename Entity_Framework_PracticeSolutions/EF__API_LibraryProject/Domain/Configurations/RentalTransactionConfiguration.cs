using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Domain.Configurations
{
    public class RentalTransactionConfiguration : IEntityTypeConfiguration<RentalTransaction>
    {
        public void Configure(EntityTypeBuilder<RentalTransaction> builder)
        {
            builder.HasKey(r => r.RentalTransactionId);

            builder.HasOne(r => r.Book)
                .WithMany(b => b.rentalTransactions)
                .HasForeignKey(r => r.BookId);

            builder.HasOne(m => m.Member)
                .WithMany(m => m.rentalTransactions)
                .HasForeignKey(r => r.MemberId);


            

        }
    }
}
