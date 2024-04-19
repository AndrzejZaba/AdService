using AdService.Application.Advertisements.CourseAdvertisements.Commands;
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
        public async Task<IActionResult> AddCourseAdvertisement()
        {
            return View(new AddCourseAdvertisementCommand());
        }
    }
}
