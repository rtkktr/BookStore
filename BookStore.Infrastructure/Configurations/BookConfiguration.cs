using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(book => book.ProductCode).IsRequired();
            builder.Property(book => book.Title).IsRequired().HasMaxLength(300);
            builder.Property(book => book.PublishYear).IsRequired();
            builder.Property(book => book.ShortDescription).IsRequired();
        }
    }
}