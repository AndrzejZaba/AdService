using AdService.Application.Advertisements.CourseAdvertisements.Commands.AddCourseAdvert;
using AdService.Application.Categories.Extensions;
using AdService.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetAddCourseAdvert;

public class GetAddCourseAdvertQueryHandler : IRequestHandler<GetAddCourseAdvertQuery, AddCourseAdvertVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public GetAddCourseAdvertQueryHandler(IApplicationDbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }
    public async Task<AddCourseAdvertVm> Handle(GetAddCourseAdvertQuery request, CancellationToken cancellationToken)
    {
        var vm = new AddCourseAdvertVm();

        vm.CourseAdvert = new AddCourseAdvertCommand
        {
            StartDate = _dateTimeService.Now,
            EndDate = _dateTimeService.Now.AddDays(7),
            CategoryId = 1
        };

        vm.AvailableCategories = await _context.Categories
            .AsNoTracking()
            .Select(x => x.ToDto())
            .ToListAsync();

        vm.PricePerDay = 0.5M;

        return vm;
    }
}
