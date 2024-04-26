using AdService.Application.Common.Models;
using MediatR;


namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;

public class GetUsersCourseAdvertsQuery : IRequest<PaginatedList<CourseAdvertBasicsDto>>
{
    public string UserId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
