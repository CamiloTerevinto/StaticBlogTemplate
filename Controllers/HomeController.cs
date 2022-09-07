using Microsoft.AspNetCore.Mvc;

namespace StaticBlogTemplate.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Blog()
    {
        return View();
    }
}
