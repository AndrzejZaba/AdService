using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
using AdService.Application.Common.Models;
using MediatR;


namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts;

public class GetSearchCourseAdvertsQuery : IRequest<PaginatedList<CourseAdvertBasicsDto>>
{
    //Search properties
    public string SearchText { get; set; }
    public int CategoryId { get; set; }

    //Paginated list properties
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

}
