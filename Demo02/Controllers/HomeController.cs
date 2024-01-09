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
            if (TempData.ContainsKey("Color")) TempData.Keep();
            return View();
        }

        public IActionResult Privacy()
        {
            if (TempData.ContainsKey("Color")) TempData.Keep();
            return View("_UnderConstruct");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Vue1()
        {
            Dictionary<string, int> notes = new Dictionary<string, int>();
            notes.Add("Thierry", 20);
            notes.Add("Aude", 12);
            notes.Add("Laurent", 18);
            notes.Add("Samuel", 8);
            notes.Add("Steve", 0);
            notes.Add("Alexandre", 10);
            notes.Add("Khun", 20);
            ViewData["limit"] = 8;
            //ViewBag.limit = 8;        //Même valeur que le ViewData["limit"]
            return View(notes);
        }

        public IActionResult Vue2(string search = null)
        {
            ArticleModel art1 = new ArticleModel()
            {
                Titre = "Les Controllers",
                Auteur = "Samuel",
                ImageURL = null
            };
            art1.Paragraphes.Add("Un controller est un point d'accès de notre projet ASP MVC à la requête du navigateur.");
            art1.Paragraphes.Add("Le controller hérite de l'Objet Controller qui contient des méthodes et propriétés permettant la gestion du retour de Vue.");
            art1.Paragraphes.Add("Les méthodes du controller se nomme des Actions et retourne de manière générale des valeurs de type IActionResult.");
            ArticleModel art2 = new ArticleModel()
            {
                Titre = "Les Views",
                Auteur = "Samuel",
                ImageURL = null
            };
            art2.Paragraphes.Add("Une Vue correspond à un code HTML/CSS/JS retourné par le controller permettant au navigateur d'afficher l'information voulue.");
            art2.Paragraphes.Add("La Vue est de type *.cshtml, ce qui veut dire qu'il intègre du CSharp et de l'HTML, mais le résultat final, généré par Razor, n'est que d'HTML.");
            HomeVue2ViewModel model = new HomeVue2ViewModel() { Titre = "L'ASP MVC" };
            model.Articles.Add(art1);
            model.Articles.Add(art2);
            if( search != null)
                model.Articles = model.Articles.Where(a => a.Titre.Contains(search) || a.Paragraphes.Where(p => p.Contains(search)).Count() > 0).ToList();
            return View(model);
        }

        public IActionResult SetBlack()
        {
            TempData["Color"] = "Black";
            return RedirectToAction("Index");
        }
    }
}
