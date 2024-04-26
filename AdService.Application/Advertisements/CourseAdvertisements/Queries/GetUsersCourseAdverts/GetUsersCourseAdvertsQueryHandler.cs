using AdService.Application.Advertisements.CourseAdvertisements.Extensions;
using AdService.Application.Common.Extensions;
using AdService.Application.Common.Interfaces;
using AdService.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;

public class GetUsersCourseAdvertsQueryHandler : IRequestHandler<GetUsersCourseAdvertsQuery, PaginatedList<CourseAdvertBasicsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetUsersCourseAdvertsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<PaginatedList<CourseAdvertBasicsDto>> Handle(GetUsersCourseAdvertsQuery request, CancellationToken cancellationToken)
    {
        var courseAdverts = _context
            .CourseAdverts
            .Where(x => x.UserId == request.UserId)
            .AsNoTracking();

        // właściwość SearchValue - do wyszukiwania np. po frazie

        var paginatedList = await courseAdverts
            .Select(x => x.ToBasicsDto())
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return paginatedList;
    }
}
