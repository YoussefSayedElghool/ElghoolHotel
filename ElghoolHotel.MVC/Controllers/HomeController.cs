using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ElghoolHotel.MVC.Controllers
{
    [Authorize]
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
        
        public IActionResult Cart()
        {
            return View();
        }
    }
}
