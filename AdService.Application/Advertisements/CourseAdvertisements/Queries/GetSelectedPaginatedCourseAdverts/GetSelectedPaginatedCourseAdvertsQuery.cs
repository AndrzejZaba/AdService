using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
using AdService.Application.Common.Models;
using MediatR;


namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSelectedPaginatedCourseAdverts;

public class GetSelectedPaginatedCourseAdvertsQuery : IRequest<PaginatedList<CourseAdvertBasicsDto>>
{
    public IQueryable<CourseAdvertBasicsDto> CourseAdverts { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
