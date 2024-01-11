using ASP_Exo_Formulaire.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Exo_Formulaire.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthLoginForm form)
        {
            return View();
        }
    }
}
