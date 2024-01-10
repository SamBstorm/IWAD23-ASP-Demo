using ASP_Exo_Formulaire.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

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
        public IActionResult Add(ProductAddForm form)
        {
            if (form is null) ModelState.AddModelError(nameof(form),"Veuillez remplir le formulaire");
            ValidateProductAddForm(form, ModelState);
            if(form.Barcode is not null && _products.ContainsKey(form.Barcode)) ModelState.AddModelError(nameof(form.Barcode), "Code-barre déjà enregistrer.");
            if (!ModelState.IsValid) return View();
            ProductModel product = new ProductModel()
            {
                Name = form.Name.Trim(),
                Barcode = form.Barcode.Trim(),
                BuyingPrice = form.BuyingPrice,
                SalePrice = form.SalePrice
            };
            _products.Add(form.Barcode, product);
            return RedirectToAction(nameof(Index));
        }

        private static void ValidateProductAddForm(ProductAddForm form, ModelStateDictionary modelState)
        {
            /* Controle des valeurs non nécessaire car remplacé par les ValidationAttributes
            if (string.IsNullOrWhiteSpace(form.Name))
                modelState.AddModelError(nameof(form.Name), "Le nom du produit est obligatoire");
            if (!string.IsNullOrWhiteSpace(form.Name) && form.Name.Length > 16)
                modelState.AddModelError(nameof(form.Name), "Le nom du produit doit contenir au maximum 16 caractères");
            if (string.IsNullOrWhiteSpace(form.Barcode))
                modelState.AddModelError(nameof(form.Barcode), "Le code-barre est obligatoire");
            if (!string.IsNullOrWhiteSpace(form.Barcode) && form.Barcode.Length != 13)
                modelState.AddModelError(nameof(form.Barcode), "Le code-barre doit être composé de 13 chiffres.");
            if (!string.IsNullOrWhiteSpace(form.Barcode) && !Regex.IsMatch(form.Barcode,"^[0-9]*$"))
                modelState.AddModelError(nameof(form.Barcode), "Le code-barre doit être composé que de chiffres.");
            */
            if (form.BuyingPrice <= 0)
                modelState.AddModelError(nameof(form.BuyingPrice), "Le prix d'achat doit être supérieur à 0 €.");
            if (form.SalePrice is not null && form.SalePrice <= form.BuyingPrice)
                modelState.AddModelError(nameof(form.SalePrice), "Le prix de vente doit être toujours supérieur au prix d'achat.");
        }
    }
}
