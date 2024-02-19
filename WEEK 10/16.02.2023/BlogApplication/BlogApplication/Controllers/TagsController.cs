using BlogApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{

    private readonly ITagRepository _tagRepository;
    public TagsController(ITagRepository tagRepository)
    {
        this._tagRepository = tagRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var tags = _tagRepository.GetAll();
        return Ok(tags);
    }
}
