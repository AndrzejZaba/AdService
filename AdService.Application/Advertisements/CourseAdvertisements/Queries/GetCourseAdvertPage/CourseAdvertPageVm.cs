using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
using AdService.Domain.Entities;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetCourseAdvertPage
{
    public class CourseAdvertPageVm
    {
        public CourseAdvertBasicsDto CourseAdvert { get; set; }
        public UserCourseAdvertPageDto User { get; set; }
    }
}