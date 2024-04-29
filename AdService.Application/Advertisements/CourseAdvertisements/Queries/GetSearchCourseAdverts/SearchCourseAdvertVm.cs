using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetAddCourseAdvert;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts
{
    public class SearchCourseAdvertVm
    {
        public GetSearchCourseAdvertsQuery SearchQuery { get; set; }
        public List<CategoryDto> AvailableCategories { get; set; }
    }
}
