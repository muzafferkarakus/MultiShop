using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ödeme Ekranı";
            ViewBag.v3 = "Kart Ödemesi";
            return View();
        }
    }
}
