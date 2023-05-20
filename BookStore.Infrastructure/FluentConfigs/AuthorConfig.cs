using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.FluentConfigs
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(author => author.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(author => author.LastName).IsRequired().HasMaxLength(150);
        }
    }
}
