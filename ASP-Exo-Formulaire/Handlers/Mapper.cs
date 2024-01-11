using ASP_Exo_Formulaire.Models;

namespace ASP_Exo_Formulaire.Handlers
{
    public static class Mapper
    {
        public static ProductListItemViewModel ToProductListItem (this ProductModel product)
        {
            if (product is null) return null;
            return new ProductListItemViewModel()
            {
                Name = product.Name,
                Barcode = product.Barcode,
                BuyingPrice = product.BuyingPrice,
                SalePrice = product.SalePrice
            };
        }
    }
}
