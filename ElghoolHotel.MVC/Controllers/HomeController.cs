using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ElghoolHotel.MVC.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Booking()
        {
            return View();
        }
    }
}
