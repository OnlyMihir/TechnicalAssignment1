using E_CommerceAPI.Dtos;

namespace E_CommerceAPI.Interfaces
{
    public interface ICheckout
    {
        Task<ItemsCheckoutResponseDto> CalculateTotalCheckoutPrice(ItemsCheckoutRequestDto itemsCheckoutRequestDto);
    }
}
