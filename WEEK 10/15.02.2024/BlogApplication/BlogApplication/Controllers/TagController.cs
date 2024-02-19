using BlogApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagRepository _tagRepository;
    
    public TagController(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var tags = _tagRepository.GetAll();
        return Ok(tags);
    }
}