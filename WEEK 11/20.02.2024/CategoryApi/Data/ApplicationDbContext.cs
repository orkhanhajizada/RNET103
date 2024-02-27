namespace CategoryApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options) { }
        public DbSet<Category> Categories { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
                new Category { Id = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
                new Category { Id = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
                new Category { Id = 4, CategoryName = "Dairy Products", Description = "Cheeses" },
                new Category { Id = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
                new Category { Id = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" },
                new Category { Id = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" },
                new Category { Id = 8, CategoryName = "Seafood", Description = "Seaweed and fish" }
            );
 
            base.OnModelCreating(modelBuilder);
        }
    }
}

