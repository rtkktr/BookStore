using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.FluentConfigs
{
    public class TranslatorConfig : IEntityTypeConfiguration<Translator>
    {
        public void Configure(EntityTypeBuilder<Translator> builder)
        {
            builder.Property(translator => translator.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(translator => translator.LastName).IsRequired().HasMaxLength(150);
        }
    }
}
