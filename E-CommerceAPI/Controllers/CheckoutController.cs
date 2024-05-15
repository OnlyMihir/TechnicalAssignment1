using E_CommerceAPI.Dtos;
using E_CommerceAPI.Interfaces;
using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_CommerceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase, ICheckout
    {
        private readonly IProductInfo productInfoServices;

        public CheckoutController(IProductInfo productInfoServices)
        {
            this.productInfoServices = productInfoServices;
        }

        [HttpPost]
        public async Task<ItemsCheckoutResponseDto> CalculateTotalCheckoutPrice(ItemsCheckoutRequestDto itemsCheckoutRequestDto)
        {
            if (itemsCheckoutRequestDto.ItemIdList.Count < 1)
            {
                // we can throw an exception here if item id list is of 0 length
            }

            // fetch all products
            List<ProductModel> productModels = await productInfoServices.GetAllProducts();

            //fetch all product discount offers
            List<ProductDiscountOfferModel> productDiscountOfferModels = await productInfoServices.GetAllProductDiscountOffers();

            // Count duplicates in list of item id's and get count of qunatity
            var itemIdsKeyCount = itemsCheckoutRequestDto.ItemIdList.GroupBy(x => x)
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);

            double totalCheckoutPrice = 0;
            // iterate over each item value and count, ex - value = 1(item id) and count = 3(item count)
            foreach (var item in itemIdsKeyCount)
            {
                bool isPriceAssigned = false;

                ProductModel? productModel = productModels.Find(x => x.ProductId == item.Value);
                if (productModel is null)
                {
                    // we can throw an exception also here
                    continue;
                }

                List<ProductDiscountOfferModel> productDiscountOfferModelList = productDiscountOfferModels.FindAll(x => x.ProductId == item.Value);
                foreach (ProductDiscountOfferModel productDiscountOfferModel in productDiscountOfferModelList)
                {
                    // logic to apply discounted amount multiple times if required
                    if (item.Count % productDiscountOfferModel.UnitQuantityToBePurchased == 0)
                    {
                        totalCheckoutPrice += (productDiscountOfferModel.DiscountedProductUnitPrice * 
                            (item.Count / productDiscountOfferModel.UnitQuantityToBePurchased));
                        isPriceAssigned = true;
                    }
                }

                if (!isPriceAssigned)
                {
                    totalCheckoutPrice += productModel.ProductUnitPrice * item.Count;
                }
            }

            return new ItemsCheckoutResponseDto() { Price = totalCheckoutPrice};
        }
    }
}
