using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.FluentConfigs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(user => user.LastName).HasMaxLength(150);
            builder.Property(user => user.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(user => user.Username).IsRequired();
            builder.Property(user => user.Password).IsRequired().HasMaxLength(100);
            builder.Property(user => user.NationalId).IsRequired().HasMaxLength(10);


        }
    }
}
