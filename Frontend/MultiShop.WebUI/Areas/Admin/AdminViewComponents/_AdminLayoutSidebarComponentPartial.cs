using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.AdminViewComponents
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
