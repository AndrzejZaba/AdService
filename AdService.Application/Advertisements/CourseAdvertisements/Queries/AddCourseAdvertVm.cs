using AdService.Application.Advertisements.CourseAdvertisements.Commands;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries
{
    public class AddCourseAdvertVm
    {
        public AddCourseAdvertCommand CourseAdvert { get; set; }
        public List<CategoryDto> AvailableCategories { get; set; }
    }
}