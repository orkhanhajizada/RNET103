using CodeFirstDb.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDb.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=CodeFirstDb;User Id=sa;Password=reallyStrongPwd123; TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Category>().Property(x => x.Description).HasMaxLength(500).IsRequired(false);

        modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(7,2)").IsRequired(false);
        modelBuilder.Entity<Product>().Property(x => x.UnitInStock).IsRequired(false);

        modelBuilder.Entity<Category>().HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
    }
}