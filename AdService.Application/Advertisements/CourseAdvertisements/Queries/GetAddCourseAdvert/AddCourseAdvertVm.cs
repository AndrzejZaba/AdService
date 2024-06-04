using AdService.Application.Advertisements.CourseAdvertisements.Commands.AddCourseAdvert;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetAddCourseAdvert
{
    public class AddCourseAdvertVm
    {
        public AddCourseAdvertCommand CourseAdvert { get; set; }
        public List<CategoryDto> AvailableCategories { get; set; }
        public decimal PricePerDay { get; set; }
    }
}