using BlogApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.ViewComponents;

public class PostViewComponent : ViewComponent
{
    private readonly BlogApplicationContext _context;

    public PostViewComponent(BlogApplicationContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult>  InvokeAsync()
    {
        var posts = await _context.Posts.Include(x=>x.Images)
            .Include(x=>x.Comments).ToListAsync();
        return View(model: posts);
    }
}