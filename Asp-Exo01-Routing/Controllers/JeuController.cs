using Microsoft.AspNetCore.Mvc;

namespace Asp_Exo01_Routing.Controllers
{
    public class JeuController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }

        public int LancerDe(int min = 1, int max = 6)
        {
            Random RNG = new Random();
            return RNG.Next(min, max+1);
        }

        public string PileOuFace()
        {
            string[] result = { "Pile", "Face" };
            return result[LancerDe(0,1)];
        }

        public string PileFace(string choix)
        {
            string coin = PileOuFace();
            if(coin == choix) return "Gagné!";
            else return "Perdu...";
        }
    }
}
