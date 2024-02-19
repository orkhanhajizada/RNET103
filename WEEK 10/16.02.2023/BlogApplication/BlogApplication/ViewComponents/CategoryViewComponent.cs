using Microsoft.AspNetCore.Mvc;
using BlogApplication.Data;

namespace BlogApplication.ViewComponents;

public class CategoryViewComponent : ViewComponent
{
    private readonly BlogApplicationContext _context;
    public CategoryViewComponent(BlogApplicationContext context)
    {
        this._context = context;
    }
    public IViewComponentResult Invoke()
    { 
        var categories = _context.Category.ToList();
        return View(model: categories);
    }
}
