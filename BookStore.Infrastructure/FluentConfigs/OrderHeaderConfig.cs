using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.FluentConfigs
{
    public class OrderHeaderConfig : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.Property(orderHeader => orderHeader.Code).IsRequired();
            builder.Property(orderHeader => orderHeader.Date).IsRequired().HasColumnType("date");
        }
    }
}
