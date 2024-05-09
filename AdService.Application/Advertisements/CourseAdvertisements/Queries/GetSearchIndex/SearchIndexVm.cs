using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetAddCourseAdvert;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchIndex
{
    public class SearchIndexVm
    {
        public GetSearchCourseAdvertsQuery SearchQuery { get; set; }
        public List<CategoryDto> AvailableCategories { get; set; }
    }
}
