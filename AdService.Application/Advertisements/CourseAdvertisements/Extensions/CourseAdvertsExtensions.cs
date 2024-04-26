using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
using AdService.Domain.Entities;


namespace AdService.Application.Advertisements.CourseAdvertisements.Extensions;

public static class CourseAdvertsExtensions
{
    public static CourseAdvertBasicsDto ToBasicsDto(this CourseAdvert courseAdvert)
    {
        if (courseAdvert == null)
            return null;

        return new CourseAdvertBasicsDto
        {
            Title = courseAdvert.Title,
            Description = courseAdvert.Description,
            ImageUrl = courseAdvert.CourseImage,
            CoursePrice = courseAdvert.CoursePrice,
            StartDate = courseAdvert.StartDate,
            WebsiteUrl = courseAdvert.WebsiteUrl
        };
    }
}
