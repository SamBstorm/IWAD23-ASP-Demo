using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Exo_Formulaire.Models
{
    public class ProductListItemViewModel
    {
        [DisplayName("Nom du produit")]
        public string Name { get; set; }
        [DisplayName("Code-barre (EAN13)")]
        public string Barcode { get; set; }
        [DisplayName("Prix d'achat")]
        [DataType(DataType.Currency)]
        public decimal BuyingPrice { get; set; }
        [DisplayName("Prix de vente")]
        [DataType(DataType.Currency)]
        public decimal? SalePrice { get; set; }

        [DisplayName("Bénéfice")]
        [DataType(DataType.Currency)]
        public decimal? Benefit
        {
            get { 
                if(SalePrice == null) return null;
                return SalePrice - BuyingPrice;
            }
        }
    }
}
