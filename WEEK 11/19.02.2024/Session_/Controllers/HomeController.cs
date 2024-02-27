using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session_.Models;
using Session_.SessionManagement;

namespace Session_.Controllers;

public class HomeController : Controller
{
    private const string SESSION_KEY_NAME = "_name";
    private const string SESSION_KEY_GROUP = "_group";
    private const string SESSION_KEY_CATEGORIES = "_categories";

    private readonly ILogger<HomeController> _logger;

    List<Category> categories = new()
    {
        new Category
            { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
        new Category
        {
            CategoryID = 2, CategoryName = "Condiments",
            Description = "Sweet and savory sauces, relishes, spreads, and seasonings"
        },
        new Category
            { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
        new Category { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses" },
        new Category
            { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
        new Category { CategoryID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" },
        new Category { CategoryID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" },
        new Category { CategoryID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" }
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.Get<List<Category>>(SESSION_KEY_CATEGORIES) == default)
        {
            HttpContext.Session.Set(SESSION_KEY_CATEGORIES, categories);
        }
        
        var kategoriler = HttpContext.Session.Get<List<Category>>(SESSION_KEY_CATEGORIES);

        return View(model: kategoriler);
    }


    // public IActionResult Index()
    // {
    //     if (string.IsNullOrEmpty(HttpContext.Session.GetString(SESSION_KEY_NAME)) ||
    //         string.IsNullOrEmpty(HttpContext.Session.GetString(SESSION_KEY_GROUP)))
    //     {
    //         HttpContext.Session.SetString(SESSION_KEY_NAME, "Murat Vuranok ->" + DateTime.Now.ToString("HH:mm:ss.fff"));
    //         HttpContext.Session.SetString(SESSION_KEY_GROUP, "RNET  103");
    //     }
    //
    //     string id = HttpContext.Session.Id;
    //     string? name = HttpContext.Session.GetString(SESSION_KEY_NAME);
    //     string? group = HttpContext.Session.GetString(SESSION_KEY_GROUP);
    //     
    //     _logger.LogInformation("Session Name: {Name}", name);
    //     _logger.LogInformation("Session Group: {Group}", group);
    //     _logger.LogInformation("Session Id: {Id}", id);
    //
    //     return View();
    // }
}