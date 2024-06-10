using Microsoft.AspNetCore.Mvc;

namespace AdService.UI.Controllers
{
    public class AdminPanelController : BaseController
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
