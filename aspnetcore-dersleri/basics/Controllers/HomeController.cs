using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers;

//localhost            => home/index
//localhost/home       => home/index
//localhost/home/index => home/index
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(Repository.Courses);
    }

    public IActionResult Contact()
    {
        return View();
    }

}
