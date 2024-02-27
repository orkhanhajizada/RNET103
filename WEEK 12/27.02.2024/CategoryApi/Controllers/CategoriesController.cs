using System.Net;
using System.Text.Json;

namespace CategoryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{

    #region Constructor
    private readonly ApplicationDbContext _context;
    private readonly IRedisService _redisService;
    public CategoriesController(ApplicationDbContext context, IRedisService redisService)
    {
        _context = context;
        _redisService = redisService;
    }
    #endregion

    const string REDIS_KEY = "categoriler";

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categoryList = await _redisService.GetAsync(REDIS_KEY);
        var categories = string.IsNullOrEmpty(categoryList)
            ? new List<Category>()
            : JsonSerializer.Deserialize<List<Category>>(categoryList);

        return Ok(categories);
    }

    [HttpPost("/set")]
    public async Task<IActionResult> Set()
    {
        var categoryList = await _redisService.GetAsync(REDIS_KEY);
        if (string.IsNullOrEmpty(categoryList))
        {
            var categories = await _context.Categories.ToListAsync();
            await _redisService.SetAsync(REDIS_KEY, JsonSerializer.Serialize(categories));
        }
        return Ok(HttpStatusCode.OK);
    }


    [HttpDelete("key")]
    public async Task<IActionResult> Delete(string key)
    {

        await _redisService.RemoveAsync(key);
        return Ok(HttpStatusCode.NoContent);
    }
}

