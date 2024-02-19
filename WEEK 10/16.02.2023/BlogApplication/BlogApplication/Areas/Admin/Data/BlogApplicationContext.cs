using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Data;

public class BlogApplicationContext : DbContext
{
    public BlogApplicationContext(DbContextOptions<BlogApplicationContext> options)
        : base(options) { }

    public DbSet<BlogApplication.Models.Category> Category { get; set; } = default!;
    public DbSet<BlogApplication.Models.Post> Posts { get; set; } = default!;
    public DbSet<BlogApplication.Models.Comment> Comments { get; set; } = default!;
    public DbSet<BlogApplication.Models.Image> Images { get; set; } = default!;
    public DbSet<BlogApplication.Models.Tag> Tags { get; set; } = default!;
}
