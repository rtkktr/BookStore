using BookStore.Saas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Saas.Infrastructure.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(publisher => publisher.Title).IsRequired().HasMaxLength(300);
            builder.Property(publisher => publisher.DateCreation).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(publisher => publisher.DateModification).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(publisher => publisher.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}