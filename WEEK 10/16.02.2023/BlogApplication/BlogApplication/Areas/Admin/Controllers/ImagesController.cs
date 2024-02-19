using BlogApplication.Data;
using BlogApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BlogApplication.Areas.Admin.Controllers;

[Area("Admin")]
public class ImagesController : Controller
{
    private readonly BlogApplicationContext _context;

    public ImagesController(BlogApplicationContext context)
    {
        _context = context;
    }


    public IActionResult Create(int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        var post = _context.Posts.FirstOrDefault(p => p.Id == id.Value);
        if (post == null)
        {
            // NotFound();
            return RedirectToAction("Index", "Posts");
        }

        return View(model: id);
    }


    [HttpPost]
    public async Task<IActionResult> Upload(int? id, IFormFile file)
    {

        if (id is null)
        {
            return RedirectToAction("index", "posts"); 
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/posts");
        var fileName = Path.GetFileName(file.FileName);
        var fullPath = Path.Combine(filePath, fileName);


        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var image = new Image();
        image.PostId = id.Value;
        image.ImageUrl = fileName;

        _context.Images.Add(image);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            StatusCode = HttpStatusCode.Created,
            FileName = fileName,
            FullPath = fullPath
        });
    }
}
