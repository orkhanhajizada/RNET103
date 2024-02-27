using System.Net;
using System.Text.Json;
using CategoryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CategoryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IRedisService _redisService;

    public CategoriesController(ApplicationDbContext context, IRedisService redisService)
    {
        _context = context;
        _redisService = redisService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        var categoryList = await _redisService.GetAsync("categories");
        var categories = string.IsNullOrEmpty(categoryList)
            ? new RedisResult<Category>()
            : JsonSerializer.Deserialize<RedisResult<Category>>(categoryList);
        return Ok(categories);
    }

    [HttpPost("/set")]
    public async Task<ActionResult<Category>> Set()
    {
        var categoryList = await _redisService.GetAsync("categories");
        if (string.IsNullOrEmpty(categoryList))
        {
            var categories = await _context.Categories.ToListAsync();
            await _redisService.SetAsync("categories", JsonSerializer.Serialize(categories));
        }

        return Ok(HttpStatusCode.OK);
    }
}


public class RedisResult<T>
{
    public List<T> Result { get; set; }
}