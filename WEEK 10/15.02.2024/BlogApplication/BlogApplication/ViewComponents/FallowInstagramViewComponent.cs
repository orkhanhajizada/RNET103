using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents;

public class FallowInstagramViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}