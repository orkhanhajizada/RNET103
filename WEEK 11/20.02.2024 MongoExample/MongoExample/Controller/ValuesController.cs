using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoExample.Entities;
using MongoExample.Repositories;

namespace MongoExample.Controller;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly CategoryRepository _categoryRepository;

    public ValuesController(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IActionResult> Post(Category category)
    {
        await _categoryRepository.AddAsync(new Category
        {
            Id = ObjectId.GenerateNewId(),
            Name = category.Name,
            Date = DateTime.UtcNow,
            Price = category.Price
        });


        return Ok(category);
    }
}