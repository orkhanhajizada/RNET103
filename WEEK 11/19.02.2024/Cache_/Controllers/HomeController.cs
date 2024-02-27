using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cache_.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Cache_.Controllers;

public class HomeController : Controller
{
    private const string CASH_CATEGORIES = "_categories";
    private readonly ILogger<HomeController> _logger;
    private readonly IMemoryCache _cache;

    public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
    {
        _logger = logger;
        _cache = cache;
    }
    
    List<Category> categories = new()
    {
        new Category { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales"},
        new Category { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings"},
        new Category { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads"},
        new Category { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses"},
        new Category { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal"},
        new Category { CategoryID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats"},
        new Category { CategoryID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd"},
        new Category { CategoryID = 8, CategoryName = "Seafood", Description = "Seaweed and fish"}
    };

    public IActionResult Index()
    {
        
        if (!_cache.TryGetValue(CASH_CATEGORIES, out List<Category> kategoriler))
        {
            MemoryCacheEntryOptions cacheEntryOptions = new()
            {
                SlidingExpiration = TimeSpan.FromSeconds(10)
            };
            _cache.Set(CASH_CATEGORIES, categories, cacheEntryOptions);
            kategoriler = categories;
        }
        return View(model: kategoriler);
    }
}