using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Domain.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.MemberId);
            builder.Property(m => m.FirstName).IsRequired();
            builder.Property(m => m.LastName).IsRequired();
            builder.Property(m => m.Address).IsRequired();
            builder.Property(m => m.Phone).IsRequired();
            builder.Property(m => m.Email).IsRequired();
            builder.Property(m => m.RentedBooks).IsRequired();
        }
    }
}
