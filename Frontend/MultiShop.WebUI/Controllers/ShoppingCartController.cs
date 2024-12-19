using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;


        public ShoppingCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Sepetim";
            ViewBag.Code = code;
            ViewBag.Rate = discountRate;
            ViewBag.NewPrice = totalNewPriceWithDiscount;
            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 20;
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            var tax = values.TotalPrice / 100 * 20;
            ViewBag.tax = tax;
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemovoBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
