using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Consumes(MediaTypeNames.Application.Json)]

public class CategoriesController : ControllerBase
{
    // [HttpGet]
    // public IActionResult Get() => Ok("Get all categories");
    //
    // [HttpGet("{id}")]
    // public IActionResult Get(int id) => Ok($"Get category by id: {id}");
    
    /// <summary>
    ///    Get all categories
    /// </summary>
    /// <remarks>
    /// Ornek liste:
    ///     Post /api/categories
    ///     {
    ///        "name": "Beverages",
    ///        "description": "Soft drinks, coffees, teas, beers, and ales"
    /// 
    ///     }
    /// </remarks>
    ///
    /// <param name="category">Eklenecek veri</param>
    /// 
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post(Category category) => Ok(category);
    
    // [HttpPut("{id}")]
    // public IActionResult Put(int id) => Ok($"Update category by id: {id}");
}