using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cookie_.Models;

namespace Cookie_.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly string COOKIE_NAME = "_survey";

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var cokie = Request.Cookies[COOKIE_NAME];
        return View(model: cokie, viewName: nameof(Index));
    }

    [HttpPost]
    public IActionResult Index(string survey)
    {
        CookieOptions options = new();
        options.Expires = DateTime.Now.AddSeconds(30);
        Response.Cookies.Append(COOKIE_NAME, survey, options);
        return RedirectToAction("Index");
    }

    public IActionResult Clear()
    {
        Response.Cookies.Append(COOKIE_NAME, "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });

        return RedirectToAction("Index");
    }


    public IActionResult Remove(string id)
    {
        Response.Cookies.Delete(id);
        return RedirectToAction("Index");
    }
}