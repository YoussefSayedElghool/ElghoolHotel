using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ElghoolHotel.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return PartialView();
        }


        public IActionResult Profile()
        {
            return View();
        }        
        
        public IActionResult Register()
        {
            return PartialView();
        }
    }
}
