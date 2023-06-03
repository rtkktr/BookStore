using BookStore.Saas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Saas.Infrastructure.Configurations
{
    public class TranslatorConfiguration : IEntityTypeConfiguration<Translator>
    {
        public void Configure(EntityTypeBuilder<Translator> builder)
        {
            builder.Property(translator => translator.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(translator => translator.LastName).IsRequired().HasMaxLength(150);
            builder.Property(translator => translator.DateCreation).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(translator => translator.DateModification).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(translator => translator.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}