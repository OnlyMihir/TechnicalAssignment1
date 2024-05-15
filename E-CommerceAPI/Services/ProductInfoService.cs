using E_CommerceAPI.Interfaces;
using E_CommerceAPI.Models;

namespace E_CommerceAPI.Services
{
    public class ProductInfoService : IProductInfo
    {
        public async Task<List<ProductDiscountOfferModel>> GetAllProductDiscountOffers()
        {
            List<ProductDiscountOfferModel> productDiscountOfferModels = new List<ProductDiscountOfferModel>();
            productDiscountOfferModels.Add(new ProductDiscountOfferModel { DiscountOfferId = 1, ProductId = 1, UnitQuantityToBePurchased = 3, DiscountedProductUnitPrice = 200 });
            productDiscountOfferModels.Add(new ProductDiscountOfferModel { DiscountOfferId = 2, ProductId = 2, UnitQuantityToBePurchased = 2, DiscountedProductUnitPrice = 120 });

            return productDiscountOfferModels;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            List<ProductModel> productModels = new List<ProductModel>();
            productModels.Add(new ProductModel { ProductId = 1, ProductName = "Item1", ProductUnitPrice = 100 });
            productModels.Add(new ProductModel { ProductId = 2, ProductName = "Item2", ProductUnitPrice = 80 });
            productModels.Add(new ProductModel { ProductId = 3, ProductName = "Item3", ProductUnitPrice = 50 });
            productModels.Add(new ProductModel { ProductId = 4, ProductName = "Item4", ProductUnitPrice = 30 });

            return productModels;
        }
    }
}
