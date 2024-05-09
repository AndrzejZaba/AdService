using AdService.Application.Advertisements.CourseAdvertisements.Commands.EditCourseAdvert;
using AdService.Application.Common.Interfaces;
using AdService.Application.Advertisements.CourseAdvertisements.Extensions;

using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetEditCourseAdvert;

public class GetEditCourseAdvertQueryHandler : IRequestHandler<GetEditCourseAdvertQuery, EditCourseAdvertCommand>
{
    private readonly IApplicationDbContext _context;

    public GetEditCourseAdvertQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditCourseAdvertCommand> Handle(GetEditCourseAdvertQuery request, CancellationToken cancellationToken)
    {
        var courseAdvert = await _context
            .CourseAdverts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.AdvertId);

        return courseAdvert.ToEditCourseAdvertCommand();
    }
}
