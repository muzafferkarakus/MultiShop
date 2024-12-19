using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductDetailService _productDetailService;
        public _ProductDetailInformationComponentPartial(IHttpClientFactory httpClientFactory, IProductDetailService productDetailService)
        {
            _httpClientFactory = httpClientFactory;
            _productDetailService = productDetailService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
            //var client = _httpClientFactory.CreateClient();

            //var responseMessage = await client.GetAsync("https://localhost:7072/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
            //    return View(values);
            //}
            //return View();
        }
    }
}
