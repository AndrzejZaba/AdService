using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
using AdService.Application.Common.Models;


namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts;

public class SearchCourseAdvertsVm
{
    //Search properties
    public string SearchText { get; set; }
    public int CategoryId { get; set; }

    public PaginatedList<CourseAdvertBasicsDto> PaginatedAdverts { get; set; }
}
