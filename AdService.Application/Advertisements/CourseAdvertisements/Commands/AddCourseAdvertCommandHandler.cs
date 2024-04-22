using AdService.Application.Common.Helpers;
using AdService.Application.Common.Interfaces;
using AdService.Domain.Entities;
using MediatR;

namespace AdService.Application.Advertisements.CourseAdvertisements.Commands;

public class AddCourseAdvertCommandHandler : IRequestHandler<AddCourseAdvertCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public AddCourseAdvertCommandHandler(IApplicationDbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(AddCourseAdvertCommand request, CancellationToken cancellationToken)
    {
        var sessionId = Guid.NewGuid().ToString();

        await AddToDatabase(request, sessionId, cancellationToken);

        await Task.FromResult(0);
        //throw new NotImplementedException();
        return Unit.Value;
    }

    private async Task AddToDatabase(AddCourseAdvertCommand request, string sessionId, CancellationToken cancellationToken)
    {
        var courseAdvert = new CourseAdvert
        {
            Id = sessionId,
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            CoursePrice = request.CoursePrice,
            Location = request.Location,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            CreationDate = _dateTimeService.Now,
            WebsiteUrl = SlugHelper.GenerateSlug(request.Title, request.Location, sessionId)
        };

    }
}
