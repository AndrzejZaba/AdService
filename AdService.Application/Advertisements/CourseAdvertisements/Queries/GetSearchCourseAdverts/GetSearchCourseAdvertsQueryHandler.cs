using AdService.Application.Advertisements.CourseAdvertisements.Extensions;
using AdService.Application.Common.Extensions;
using AdService.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts;

public class GetSearchCourseAdvertsQueryHandler : IRequestHandler<GetSearchCourseAdvertsQuery, SearchCourseAdvertsVm>
{
    private readonly IApplicationDbContext _context;

    public GetSearchCourseAdvertsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SearchCourseAdvertsVm> Handle(GetSearchCourseAdvertsQuery request, CancellationToken cancellationToken)
    {
        var vm = new SearchCourseAdvertsVm();

        var searchedCourseAdverts = _context
            .CourseAdverts
            .Where(x => x.CategoryId == request.CategoryId);

        if (!string.IsNullOrWhiteSpace(request.SearchText))
            searchedCourseAdverts = searchedCourseAdverts.Where(x => x.Title.Contains(request.SearchText));

        searchedCourseAdverts = searchedCourseAdverts.AsNoTracking();

        var paginatedList = await searchedCourseAdverts
            .Select(x => x.ToBasicsDto())
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        vm.SearchText = request.SearchText;
        vm.CategoryId = request.CategoryId;
        vm.PaginatedAdverts = paginatedList;

        return vm;

    }

}
