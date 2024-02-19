using BlogApplication.Data;
using BlogApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents;

public class PostViewComponent : ViewComponent
{ 
    public IViewComponentResult Invoke(Post model)
    { 
        return View(model);
    }
}
