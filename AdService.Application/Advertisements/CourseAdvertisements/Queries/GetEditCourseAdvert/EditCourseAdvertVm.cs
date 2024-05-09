using AdService.Application.Advertisements.CourseAdvertisements.Commands.EditCourseAdvert;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetAddCourseAdvert;


namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetEditCourseAdvert;

public class EditCourseAdvertVm
{
    public EditCourseAdvertCommand CourseAdvert { get; set; }
    public List<CategoryDto> AvailableCategories { get; set; }
}
