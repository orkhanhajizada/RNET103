using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents;

public class PopularTagsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
