﻿using BookStore.Saas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Saas.Infrastructure.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(author => author.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(author => author.LastName).IsRequired().HasMaxLength(150);
            builder.Property(author => author.DateCreation).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(author => author.DateModification).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(author => author.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}