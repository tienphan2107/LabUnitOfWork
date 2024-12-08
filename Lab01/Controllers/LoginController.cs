using Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab01.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            if (account.username == "admin" && account.password == "admin")
            {
                return View("Success");
            }
            else
            {
                return View("Fail");
            }
        }
    }
}
