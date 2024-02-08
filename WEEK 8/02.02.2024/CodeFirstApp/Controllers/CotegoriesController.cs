using CodeFirstApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContextFactory _contextFactory;
    
    public CategoriesController(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _contextFactory.CreateContext().Categories.ToListAsync();
        return Ok(categories);
    }
}