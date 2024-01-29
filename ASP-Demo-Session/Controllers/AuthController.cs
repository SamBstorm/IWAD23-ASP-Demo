using ASP_Demo_Session.Handlers;
using ASP_Demo_Session.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Demo_Session.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserSessionManager _userSessionManager;
        public AuthController(UserSessionManager userSessionManager)
        {
            _userSessionManager = userSessionManager;
        }
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AuthLoginForm form)
        {
            try
            {
                if (form is null) ModelState.AddModelError(nameof(form), "Pas de formulaire reçu.");
                if (!(form.Email == "admin@test.be" && form.Password == "Test1234=")) ModelState.AddModelError(nameof(form), "Utilisateur non-reconnu");
                if (!ModelState.IsValid) throw new Exception();
                CurrentUser user = new CurrentUser() { User_Id = Guid.NewGuid(), Email =form.Email};
                _userSessionManager.LogUser(user);
                return RedirectToAction(nameof(Index), "Home");
            }
            catch 
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout(AuthLogoutForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _userSessionManager.DisconnectUser();
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }
    }
}
