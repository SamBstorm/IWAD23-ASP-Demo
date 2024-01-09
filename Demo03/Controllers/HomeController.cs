using Demo03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo03.Controllers
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
            return View();
        }

        public IActionResult Search(string query)
        {
            if(string.IsNullOrEmpty(query)) return RedirectToAction(nameof(Index));
            List<string> fausseDatabase = new List<string>();
            fausseDatabase.AddRange(new string[] { "ASP CORE MVC", "ASP NET MVC", "Controller MVC", "DOT NET", "Framework" });
            HomeSearchViewModel model = new HomeSearchViewModel() { Query = query.Trim() };
            model.Results = fausseDatabase.Where(d => d.ToUpper().Contains(model.Query.ToUpper())).ToList();
            return View(model);
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
    }
}
