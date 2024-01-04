using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
