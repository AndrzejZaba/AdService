using AdService.Application.Advertisements.CourseAdvertisements.Commands.AddCourseAdvert;
using AdService.Application.Advertisements.CourseAdvertisements.Queries;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetAddCourseAdvert;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetCourseAdvertPage;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetEditCourseAdvert;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
using AdService.Application.Common.Extensions;
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
        
        public async Task<IActionResult> UserCourseAdverts(int page = 1)
        {
            return View(await Mediator.Send(new GetUsersCourseAdvertsQuery
            {
                UserId = UserId,
                PageSize = 4,
                PageNumber = page
            }));
        }
        
        public async Task<IActionResult> SearchedCoursesList(string searchedText, int categoryId, int page = 1)
        {
            var result = new GetSearchCourseAdvertsQuery
            {
                SearchText = searchedText,
                CategoryId = categoryId,
                PageNumber = page,
                PageSize = 9
            };
            return View(await Mediator.Send(result));
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

            return RedirectToAction("Checkout", "Payment", new { 
                title = vm.CourseAdvert.Title, 
                description = vm.CourseAdvert.Description.ExtractTextFromHtml().TakeFirstNChar(100)
            });

            // Dodanie ogłoszenia bez płatności
            //return RedirectToAction("UserCourseAdverts");
        }

        [Route("courseadvert/{courseAdvertPageUrl}")]
        public async Task<IActionResult> CourseAdvertPage (string courseAdvertPageUrl)
        {
            var page = await Mediator.Send(new GetCourseAdvertPageQuery 
            { 
                Url = courseAdvertPageUrl
            });

            if (page == null)
                return NotFound();

            return View(page);
        }

        [HttpGet]
        [Route("Advertisements/EditCourseAdvert/{advertId}")]
        public async Task<IActionResult> EditCourseAdvert(string advertId)
        {
            return View(await Mediator.Send(new GetEditCourseAdvertQuery { AdvertId = advertId }));
        }
    }
}
