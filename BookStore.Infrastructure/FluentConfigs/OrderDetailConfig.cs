using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.FluentConfigs
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(orderDetail => orderDetail.Quantity).IsRequired();
            builder.Property(orderDetail => orderDetail.UnitPrice).IsRequired();
        }
    }
}
