using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Areas.Admin.Controllers
{

    [Area("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }
    }
}
