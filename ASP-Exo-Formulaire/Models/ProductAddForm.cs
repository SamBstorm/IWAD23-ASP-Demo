using System.ComponentModel.DataAnnotations;

namespace ASP_Exo_Formulaire.Models
{
    public class ProductAddForm
    {
        [Required(ErrorMessage="Le nom du produit est obligatoire")]
        [MinLength(2, ErrorMessage = "Le nom du produit doit être composé de minimum 2 caractères")]
        [MaxLength(16, ErrorMessage = "Le nom du produit doit être composé de maximum 16 caractères")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Le code-barre est obligatoire")]
        [StringLength(maximumLength: 13, MinimumLength =13, ErrorMessage = "Le code-barre doit être composé de 13 chiffres")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Le code-barre ne doit être composé que de chiffres")]
        public string Barcode { get; set; }
        [Required(ErrorMessage = "Le prix d'achat est obligatoire")]
        public decimal BuyingPrice { get; set; }
        public decimal? SalePrice { get; set; }
    }
}
