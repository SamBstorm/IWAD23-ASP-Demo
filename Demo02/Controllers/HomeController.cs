using Demo02.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo02.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            Title = "Démonstration vue Razor";
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("_UnderConstruct");
        }

        public IActionResult Privacy()
        {
            return View("_UnderConstruct");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Vue1()
        {
            ViewData["limit"] = 8;
            return View();
        }
    }
}
