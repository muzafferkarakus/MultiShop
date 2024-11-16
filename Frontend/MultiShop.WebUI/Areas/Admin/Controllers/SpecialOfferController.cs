using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/Discounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        //[HttpGet]
        //[Route("CreateSpecialOffer")]
        //public async Task<IActionResult> CreateSpecialOffer()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Route("CreateSpecialOffer")]
        //public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        //{
        //    return View();
        //}

        //[Route("DeleteSpecialOffer/{id]")]
        //public async Task<IActionResult> DeleteSpecialOffer()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[Route("UpdateSpecialOffer/{id]")]
        //public async Task<IActionResult> UpdateSpecialOffer()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Route("UpdateSpecialOffer/{id]")]
        //public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        //{
        //    return View();
        //}

    }
}
