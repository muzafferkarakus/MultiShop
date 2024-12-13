using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByDiscountCodeDto> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync($"discounts/GetCodeDetailByCode/{code}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByDiscountCodeDto>();
            return values;
        }
    }
}
