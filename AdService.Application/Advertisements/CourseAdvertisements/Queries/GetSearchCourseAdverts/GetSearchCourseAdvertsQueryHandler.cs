using AdService.Application.Advertisements.CourseAdvertisements.Extensions;
using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts;
using AdService.Application.Common.Extensions;
using AdService.Application.Common.Interfaces;
using AdService.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts;

public class GetSearchCourseAdvertsQueryHandler : IRequestHandler<GetSearchCourseAdvertsQuery, PaginatedList<CourseAdvertBasicsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetSearchCourseAdvertsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<CourseAdvertBasicsDto>> Handle(GetSearchCourseAdvertsQuery request, CancellationToken cancellationToken)
    {
        var searchedCourseAdverts = _context
            .CourseAdverts
            //.Where(x => x.Title.Contains(request.SearchText) && x.CategoryId == request.CategoryId)
            .Where(x => x.CategoryId == request.CategoryId);

        if (!string.IsNullOrWhiteSpace(request.SearchText))
            searchedCourseAdverts = searchedCourseAdverts.Where(x => x.Title.Contains(request.SearchText));

        searchedCourseAdverts = searchedCourseAdverts.AsNoTracking();

        var paginatedList = await searchedCourseAdverts
            .Select(x => x.ToBasicsDto())
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return paginatedList;

    }

    //public async Task<IQueryable<CourseAdvertBasicsDto>> Handle(GetSearchCourseAdvertsQuery request, CancellationToken cancellationToken)
    //{
    //    var searchedCourseAdverts = await _context
    //        .CourseAdverts
    //        .Where(x => x.Title.Contains(request.SearchText) && x.CategoryId == request.CategoryId)
    //        .AsNoTracking()
    //        .Select(x => x.ToBasicsDto())
    //        .ToListAsync();

    //    return searchedCourseAdverts.AsQueryable();
    //}
}
