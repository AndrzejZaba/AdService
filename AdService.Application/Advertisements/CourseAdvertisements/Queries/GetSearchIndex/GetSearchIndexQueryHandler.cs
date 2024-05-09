using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchCourseAdverts;
using AdService.Application.Categories.Extensions;
using AdService.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetSearchIndex;

public class GetSearchIndexQueryHandler : IRequestHandler<GetSearchIndexQuery, SearchIndexVm>
{
    private readonly IApplicationDbContext _context;
    public GetSearchIndexQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<SearchIndexVm> Handle(GetSearchIndexQuery request, CancellationToken cancellationToken)
    {
        var vm = new SearchIndexVm();

        vm.SearchQuery = new GetSearchCourseAdvertsQuery { CategoryId = 1};

        vm.AvailableCategories = await _context.Categories
            .AsNoTracking()
            .Select(x => x.ToDto())
            .ToListAsync();

        return vm;
    }
}
