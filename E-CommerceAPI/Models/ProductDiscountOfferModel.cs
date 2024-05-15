namespace E_CommerceAPI.Models
{
    public class ProductDiscountOfferModel
    {
        public int DiscountOfferId { get; set; }
        public int ProductId { get; set; }
        public int UnitQuantityToBePurchased { get; set; }
        public double DiscountedProductUnitPrice { get; set; }
    }
}
