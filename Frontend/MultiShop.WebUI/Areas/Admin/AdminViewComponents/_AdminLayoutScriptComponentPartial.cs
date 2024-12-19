using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.AdminViewComponents
{
    public class _AdminLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
