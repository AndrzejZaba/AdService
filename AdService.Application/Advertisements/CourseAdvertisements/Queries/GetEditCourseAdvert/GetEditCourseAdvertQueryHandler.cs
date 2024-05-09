using AdService.Application.Advertisements.CourseAdvertisements.Commands.EditCourseAdvert;
using AdService.Application.Common.Interfaces;
using AdService.Application.Advertisements.CourseAdvertisements.Extensions;

using MediatR;
using Microsoft.EntityFrameworkCore;
using AdService.Application.Categories.Extensions;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetEditCourseAdvert;

public class GetEditCourseAdvertQueryHandler : IRequestHandler<GetEditCourseAdvertQuery, EditCourseAdvertVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditCourseAdvertQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditCourseAdvertVm> Handle(GetEditCourseAdvertQuery request, CancellationToken cancellationToken)
    {
        var vm = new EditCourseAdvertVm();

        var courseAdvert = await _context
            .CourseAdverts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.AdvertId);

        vm.CourseAdvert = courseAdvert.ToEditCourseAdvertCommand();

        vm.AvailableCategories = await _context.Categories
            .AsNoTracking()
            .Select(x => x.ToDto())
            .ToListAsync();


        return vm;
    }
}
