using CodeFirstDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirstDb.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);
    }
}