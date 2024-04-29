using AdService.Application.Advertisements.CourseAdvertisements.Extensions;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
using AdService.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts;

public class GetSearchCourseAdvertsQueryHandler : IRequestHandler<GetSearchCourseAdvertsQuery, IQueryable<CourseAdvertBasicsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetSearchCourseAdvertsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IQueryable<CourseAdvertBasicsDto>> Handle(GetSearchCourseAdvertsQuery request, CancellationToken cancellationToken)
    {
        var searchedCourseAdverts = await _context
            .CourseAdverts
            .Where(x => x.Title.Contains(request.SearchText) && x.CategoryId == request.CategoryId)
            .AsNoTracking()
            .Select(x => x.ToBasicsDto())
            .ToListAsync();

        return searchedCourseAdverts.AsQueryable();
    }
}
