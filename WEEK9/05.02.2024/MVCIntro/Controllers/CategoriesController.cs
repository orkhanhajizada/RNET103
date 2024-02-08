using Microsoft.AspNetCore.Mvc;
using MVCIntro.Models;
using MVCIntro.ViewModels;

namespace MVCIntro.Controllers;

public class CategoriesController : Controller
{
    private static List<Category> _categories =
    [
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
    ];

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(string categoryName, string description)
    {
        var category = new Category
        {
            CategoryID = _categories.Count + 1,
            CategoryName = categoryName,
            Description = description
        };
        _categories.Add(category);
        
        var vm = new CategoryVm
        {
            Description = "This is a list of categories from ViewModel",
            Categories = _categories
        };
        return View(model: vm);
    }

    #region Send data to  view (VM, ViewData, ViewBag, TempData, Tuple)

    // public IActionResult Index()
    // {
    //     ViewData["CategoryListViewData"] = _categories;
    //     ViewData["ViewDataDescription"] = "This is a list of categories from ViewData";
    //
    //     ViewBag.CategoryListViewBag = _categories;
    //     ViewBag.ViewBagDescription = "This is a list of categories from ViewBag";
    //
    //     TempData["tData"] = "This is a list of categories from TempData";
    //
    //     var vm = new CategoryVm
    //     {
    //         Description = "This is a list of categories from ViewModel",
    //         Categories = _categories
    //     };
    //
    //     var tuple = new Tuple<List<Category>, string, DateTime, List<Category>,string>(_categories, "Description",
    //         DateTime.UtcNow, _categories,"Item5");
    //     return View(model: tuple);
    //     // return View(model: _categories);
    // }
    //
    // public IActionResult TempDataView()
    // {
    //     TempData["CategoriesTempData"] = "Categories";
    //     TempData["TempDataDescription"] = "This is a list of categories from TempData";
    //
    //     return View();
    // }

    // public IActionResult Index()
    // {
    //     string firstName = "John";
    //     return View(model: firstName);
    // }

    #endregion


}