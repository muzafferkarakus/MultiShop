using MultiShop.DtoLayer.OrderDtos.OrderAddressDto;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public class OrderAddressServices : IOrderAddressServices
    {
        private readonly HttpClient _httpClient;

        public OrderAddressServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createOrderAddressDto);
        }
    }
}
