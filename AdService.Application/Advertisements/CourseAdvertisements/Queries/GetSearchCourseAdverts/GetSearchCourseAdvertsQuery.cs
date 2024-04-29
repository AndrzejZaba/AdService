using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetAddCourseAdvert;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
using MediatR;


namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts;

public class GetSearchCourseAdvertsQuery : IRequest<IQueryable<CourseAdvertBasicsDto>>
{
    public string SearchText { get; set; }
    public int CategoryId { get; set; }

}
