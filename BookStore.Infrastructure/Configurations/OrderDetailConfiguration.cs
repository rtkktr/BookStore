using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(orderDetail => new { orderDetail.BookId, orderDetail.OrderHeaderId });
            builder.Property(orderDetail => orderDetail.Quantity).IsRequired();
            builder.Property(orderDetail => orderDetail.UnitPrice).IsRequired();
            builder.Property(orderDetail => orderDetail.DateCreation).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(orderDetail => orderDetail.DateModification).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(orderDetail => orderDetail.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}