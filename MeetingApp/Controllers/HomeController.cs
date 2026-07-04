using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController: Controller
    {
        //localhost
        //localhost/home
        //localhost/home/index
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;

            // ViewBag.Selamlama = saat > 12 ? "iyi günler" : "Günaydın";
            // ViewBag.UserName = "Şahin";

            ViewData["Selamlama"] = saat > 12 ? "iyi günler" : "Günaydın";
            ViewData["UserName"] = "Şahin";

            return View();
        }
    }  
}