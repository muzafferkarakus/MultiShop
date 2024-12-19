using MultiShop.DtoLayer.OrderDtos.OrderAddressDto;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressServices
    {
        //Task<List<ResultOrderAddressDto>> GetAllOrderAddressAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        //Task UpdateOrderAddressAsync(UpdateOrderAddressDto updateOrderAddressDto);
        //Task DeleteOrderAddressAsync(string id);
        //Task<UpdateOrderAddressDto> GetByIdOrderAddressAsync(string id);
    }
}
