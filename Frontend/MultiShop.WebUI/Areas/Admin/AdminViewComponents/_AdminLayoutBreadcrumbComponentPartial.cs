using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.AdminViewComponents
{
    public class _AdminLayoutBreadcrumbComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
