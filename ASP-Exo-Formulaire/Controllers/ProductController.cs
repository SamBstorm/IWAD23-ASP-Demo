using ASP_Exo_Formulaire.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Exo_Formulaire.Controllers
{
    public class ProductController : Controller
    {
        private static Dictionary<string,ProductModel> _products = new Dictionary<string, ProductModel>();

        /// <summary>
        /// Route : /Product/
        /// Correspond à l'action d'accès à la liste de produit
        /// </summary>
        /// <returns>Vue de la liste des produits</returns>
        public IActionResult Index()
        {
            return View(_products.Values.ToList());
        }
        /// <summary>
        /// Route GET : /Product/Add
        /// Correspond à l'action d'affichage du formulaire d'ajout de produit
        /// </summary>
        /// <returns>Vue du formaulaire d'ajout</returns>
        [HttpGet]
        public IActionResult Add()
        { 
            return View();
        }
        /// <summary>
        /// Route POST : /Product/Add
        /// Correspond à l'action de traitement du formulaire.
        /// </summary>
        /// <param name="form">Contenu du formulaire</param>
        /// <returns>Redirection vers la vue de Liste si le formulaire est valide</returns>
        [HttpPost]
        public IActionResult Add(IFormCollection form)
        {
            return View();
        }
    }
}
