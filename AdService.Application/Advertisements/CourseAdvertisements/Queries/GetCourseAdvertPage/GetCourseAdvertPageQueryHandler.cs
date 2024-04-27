using AdService.Application.Advertisements.CourseAdvertisements.Extensions;
using AdService.Application.Common.Interfaces;
using AdService.Application.Users.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetCourseAdvertPage;

public class GetCourseAdvertPageQueryHandler : IRequestHandler<GetCourseAdvertPageQuery, CourseAdvertPageVm>
{
    private readonly IApplicationDbContext _context;

    public GetCourseAdvertPageQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CourseAdvertPageVm> Handle(GetCourseAdvertPageQuery request, CancellationToken cancellationToken)
    {
        var courseAdvert = await _context
            .CourseAdverts
            .AsNoTracking()
            .Select(x => x.ToBasicsDto())
            .FirstOrDefaultAsync(x => x.WebsiteUrl == request.Url);

        var user = await _context
            .Users
            .AsNoTracking()
            .Include(x => x.Client)
            .Select(x => x.ToUserCourseAdvertPageDtoDto())
            .FirstOrDefaultAsync(x => x.Id == request.UserId);

        var pageVm = new CourseAdvertPageVm
        {
            CourseAdvert = courseAdvert,
            User = user
        };

        return pageVm;
    }
}
