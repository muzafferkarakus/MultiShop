using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featureslider", createFeatureSliderDto);
        }
        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featureslider?id=" + id);
        }
        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("featureslider/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();
            return values;
        }
        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("featureslider");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
            return values;
        }
        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featureslider", updateFeatureSliderDto);
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }
    }
}
