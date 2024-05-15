using E_CommerceAPI.Models;

namespace E_CommerceAPI.Interfaces
{
    public interface IProductInfo
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<List<ProductDiscountOfferModel>> GetAllProductDiscountOffers();
    }
}
