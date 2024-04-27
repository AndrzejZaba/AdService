using AdService.Application.Advertisements.CourseAdvertisements.Commands.AddCourseAdvert;
using AdService.Application.Advertisements.CourseAdvertisements.Queries;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetAddCourseAdvert;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
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
        public async Task<IActionResult> MyCoursesAdvertisements(int page = 1)
        {
            return View(await Mediator.Send(new GetUsersCourseAdvertsQuery
            {
                UserId = UserId,
                PageSize = 3,
                PageNumber = page
            }));
        }
        public async Task<IActionResult> AddCourseAdvertisement()
        {
            return View(await Mediator.Send(new GetAddCourseAdvertQuery()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourseAdvertisement(AddCourseAdvertVm vm)
        {
            var result = await MediatorSendValidate(new AddCourseAdvertCommand
            {
                Title = vm.CourseAdvert.Title,
                Description = vm.CourseAdvert.Description,
                Location = vm.CourseAdvert.Location,
                CoursePrice = vm.CourseAdvert.CoursePrice,
                Price = vm.CourseAdvert.Price,
                ImageFile = vm.CourseAdvert.ImageFile,
                CategoryId = vm.CourseAdvert.CategoryId,
                UserId = UserId,
                StartDate = vm.CourseAdvert.StartDate,
                EndDate = vm.CourseAdvert.EndDate
            });

            if (!result.IsValid)
                return View(vm);

            TempData["Success"] = "New course advert has beed added!";


            // Dodanie ogłoszenia bez płatności
            return RedirectToAction("MyCoursesAdvertisements");
        }
    }
}
