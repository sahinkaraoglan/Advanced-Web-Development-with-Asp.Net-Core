using MeetingApp.Models;
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


            var meetingInfo = new MeetingInfo()
            {
                Id = 1 ,
                Location = "Kayseri - Kadir Has Kongre Merkezi",
                Date = new DateTime(2026, 01, 20, 20, 0, 0),
                NumberOfPeople = 100
            };

            return View(meetingInfo);
        }
    }  
}