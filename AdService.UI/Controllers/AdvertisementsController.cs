using Microsoft.AspNetCore.Mvc;

namespace AdService.UI.Controllers
{
    public class AdvertisementsController : BaseController
    {
        public IActionResult MyJobAdvertisements()
        {
            return View();
        } 
        public IActionResult MyCoursesAdvertisements()
        {
            return View();
        }
    }
}
