using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentService _commentService;
        private readonly IDiscountStatisticService _discountService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentService commentService, IDiscountStatisticService discountService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _discountService = discountService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var brandCount = await _catalogStatisticService.GetBrandCount();
            var categoryCount = await _catalogStatisticService.GetCategoryCount();
            var productCount = await _catalogStatisticService.GetProductCount();
            var maxPrice = await _catalogStatisticService.GetMaxPriceProductName();
            var minPrice = await _catalogStatisticService.GetMinPriceProductName();
            //var avgPrice = await _catalogStatisticService.GetProductAvgPrice();
            var userCount = await _userStatisticService.GetUsercount();
            var totalCommentCount = await _commentService.GetTotalCommentCount();
            var totalActiveCount = await _commentService.GetActiveCommentCount();
            var totalPassiveCount = await _commentService.GetPassiveCommentCount();
            var couponCount = await _discountService.GetDiscountCouponCount();
            var messageCount = await _messageStatisticService.GetTotalMessageCount();

            ViewBag.brand = brandCount;
            ViewBag.category = categoryCount;
            ViewBag.product = productCount;
            ViewBag.max = maxPrice;
            ViewBag.min = minPrice;
            //ViewBag.avg = avgPrice;
            ViewBag.userCount = userCount;
            ViewBag.totalComment = totalCommentCount;
            ViewBag.activeComment = totalActiveCount;
            ViewBag.passiveComment = totalPassiveCount;
            ViewBag.couponCount = couponCount;
            ViewBag.messageCount = messageCount;
            return View();
        }
    }
}
