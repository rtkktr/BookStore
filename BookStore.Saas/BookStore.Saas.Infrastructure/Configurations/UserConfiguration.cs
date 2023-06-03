using BookStore.Saas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Saas.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(user => user.LastName).HasMaxLength(150);
            builder.Property(user => user.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(user => user.Email).HasMaxLength(100);
            builder.Property(user => user.Username).IsRequired().HasMaxLength(50);
            builder.Property(user => user.Password).IsRequired().HasMaxLength(50);
            builder.Property(user => user.NationalId).HasMaxLength(20);
            builder.Property(user => user.DateCreation).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(user => user.DateModification).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(user => user.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}