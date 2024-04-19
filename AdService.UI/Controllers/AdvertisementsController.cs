using AdService.Application.Advertisements.CourseAdvertisements.Commands;
using AdService.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdService.UI.Controllers
{
    public class AdvertisementsController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;

        public AdvertisementsController(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }
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
            return View(new AddCourseAdvertisementCommand {StartDate = _dateTimeService.Now, EndDate = _dateTimeService.Now.AddDays(7) });
        }
    }
}
