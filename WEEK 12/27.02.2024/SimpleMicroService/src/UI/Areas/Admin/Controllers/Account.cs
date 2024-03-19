using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers;


[Area("admin")]
public class Account : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}
