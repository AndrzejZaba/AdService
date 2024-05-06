using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchIndex;
using AdService.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdService.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            //await Mediator.Send(new )

            return View(await Mediator.Send(new GetSearchIndexQuery()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SearchCourseAdvertVm vm, int page = 1)
        {
            //await Mediator.Send(new )
            //var result = new GetSearchCourseAdvertsQuery
            //{
            //    SearchText = vm.SearchQuery.SearchText,
            //    CategoryId = vm.SearchQuery.CategoryId,
            //    PageNumber = page,
            //    PageSize = 9
            //};

            //return View(await Mediator.Send(new GetSearchIndexQuery()));
            return RedirectToAction("SearchedCoursesList", "Advertisements", new { text = vm.SearchQuery.SearchText, categoryId = vm.SearchQuery.CategoryId});
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}