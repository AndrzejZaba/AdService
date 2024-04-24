using AdService.Application.Advertisements.CourseAdvertisements.Commands;
using AdService.Application.Advertisements.CourseAdvertisements.Queries;
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
            return View(await Mediator.Send(new GetAddCourseAdvertQuery()));
        }
    }
}
