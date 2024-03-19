using CleanArchitecture.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CleanArchitecture.WebApi.Controllers.v1;

/// <summary>
/// Categories Api Controller
/// </summary>
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private List<Category> Categories = new List<Category>
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
            { CategoryID = 5, CategoryName = "GrainsCereals", Description = "Breads, crackers, pasta, and cereal" },
        new Category { CategoryID = 6, CategoryName = "MeatPoultry", Description = "Prepared meats" },
        new Category { CategoryID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" },
        new Category { CategoryID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" }
    };

    /// <summary>
    /// Yeni bir kategori ekle
    /// </summary>
    /// <remarks>
    /// Örnek istek:
    ///
    ///     POST /Categories
    ///     {
    ///        "categoryName" : "Beverages",
    ///        "description"  : "Soft, Tea"
    ///     }
    ///     
    /// </remarks>
    /// <param name="category">Eklenecek olan yeni kategori</param>
    /// <returns>Eklenen Kategoriyi teslim eder.</returns>
    /// <response code="200">Kategori başarıyla eklendi.</response>
    /// <response code="400">Gönderilen kategori bilgileri geçersiz.</response>   
    [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public IActionResult Post(Category category)
    {
        return Ok(category);
    }


    [HttpGet] public IActionResult Get() => Ok(Categories);
    [HttpGet("{id}")] public IActionResult Get(int id) => Ok(Categories.FirstOrDefault(x => x.CategoryID == id)); 
    [HttpPut] public IActionResult Put(Category category) => Ok(category);
    [HttpDelete] public IActionResult Delete(int id) => Ok("Delete " + id);
}