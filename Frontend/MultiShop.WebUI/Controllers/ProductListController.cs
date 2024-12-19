using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            return View();
        }
        public IActionResult ProductDetails(string id)
        {
            ViewBag.x = id;
            ViewBag.i = id;
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Listesi";
            ViewBag.v3 = "Ürün Detayları";
            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "test";
            createCommentDto.Raiting = 1;
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Status = false;
            createCommentDto.ProductId = "6737a8230a3ac42dc8e96b9a";
            var client = _httpClientFactory.CreateClient();
            var jsonDate = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7104/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();
        }
    }

}
