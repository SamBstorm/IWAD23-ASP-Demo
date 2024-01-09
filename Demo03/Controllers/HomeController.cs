using Demo03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(HomeIndexForm form)
        {
            if (form is null) return View();
            ValidateHomeIndexForm(form, ModelState);
            if(!ModelState.IsValid) return View();
            List<string> fausseDatabase = new List<string>();
            fausseDatabase.AddRange(new string[] { "ASP CORE MVC", "ASP NET MVC", "Controller MVC", "DOT NET", "Framework" });
            HomeSearchViewModel model = new HomeSearchViewModel() { Query = form.Query.Trim() };
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

        #region Validation methods

        private static void ValidateHomeIndexForm(HomeIndexForm form, ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(form.Query)) 
                modelState.AddModelError(nameof(form.Query),"La recherche est obligatoire");

            if (!string.IsNullOrWhiteSpace(form.Query) && form.Query.Trim().Length < 3)
                modelState.AddModelError(nameof(form.Query), "La recherche doit contenir au minimum 3 caractères.");
        }

        #endregion
    }
}
