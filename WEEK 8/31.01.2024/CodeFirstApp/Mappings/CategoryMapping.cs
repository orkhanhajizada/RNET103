using CodeFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirstApp.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.Property(c => c.CategoryID);
        builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(15);
        builder.Property(c => c.Description).IsRequired(false);
    }
}