using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configurations
{
    public class OrderHeaderConfiguration : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.Property(orderHeader => orderHeader.Code).IsRequired();
            builder.Property(orderHeader => orderHeader.Date).HasDefaultValue(DateTime.Now);
            builder.Property(orderHeader => orderHeader.DateCreation).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(orderHeader => orderHeader.DateModification).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(orderHeader => orderHeader.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}