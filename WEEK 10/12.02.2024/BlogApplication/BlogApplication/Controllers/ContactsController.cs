using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers;

public class ContactsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
