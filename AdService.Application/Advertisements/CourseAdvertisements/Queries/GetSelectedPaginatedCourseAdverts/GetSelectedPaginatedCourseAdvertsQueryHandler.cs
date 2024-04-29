using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
using AdService.Application.Common.Extensions;
using AdService.Application.Common.Models;
using MediatR;


namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSelectedPaginatedCourseAdverts;

public class GetSelectedPaginatedCourseAdvertsQueryHandler : IRequestHandler<GetSelectedPaginatedCourseAdvertsQuery, PaginatedList<CourseAdvertBasicsDto>>
{
    public async Task<PaginatedList<CourseAdvertBasicsDto>> Handle(GetSelectedPaginatedCourseAdvertsQuery request, CancellationToken cancellationToken)
    {
        return await request.CourseAdverts.PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
