using Demo01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Entrée dans Home/Index");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Entrée dans Home/Privacy");
            return View();
        }

        [Route("{nb1}/plus/{nb2}")]
        [Route("{nb1}/add/{nb2}")]
        [Route("{nb1}/+/{nb2}")]
        public int Addition(int nb1, int nb2)
        {
            try
            {
                return(checked(nb1 + nb2));
            }
            catch (Exception)
            {
                _logger.LogError("Valeur maximale atteinte...");
                return 0;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
