namespace ASP_Exo_Formulaire.Models
{
    public class ProductAddForm
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal? SalePrice { get; set; }
    }
}
