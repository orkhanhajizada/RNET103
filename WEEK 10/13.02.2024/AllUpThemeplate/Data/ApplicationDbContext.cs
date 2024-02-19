using AllUpThemeplate.Models;
using Microsoft.EntityFrameworkCore;

namespace AllUpThemeplate.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    public DbSet<Feature> Features { get; set; }
}