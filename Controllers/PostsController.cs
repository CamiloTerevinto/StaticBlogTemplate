using Microsoft.AspNetCore.Mvc;

namespace StaticBlogTemplate.Controllers;

public class PostsController : Controller
{
    public IActionResult WelcomeToMyBlog()
    {
        return View();
    }
}
