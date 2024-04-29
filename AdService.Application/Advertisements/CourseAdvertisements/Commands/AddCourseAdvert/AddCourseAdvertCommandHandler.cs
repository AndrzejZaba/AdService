using AdService.Application.Common.Helpers;
using AdService.Application.Common.Interfaces;
using AdService.Domain.Entities;
using MediatR;

namespace AdService.Application.Advertisements.CourseAdvertisements.Commands.AddCourseAdvert;

public class AddCourseAdvertCommandHandler : IRequestHandler<AddCourseAdvertCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly IFileImageManagerService _fileImageManagerService;
    private readonly IFileImageNameService _fileImageNameService;

    public AddCourseAdvertCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService,
        IFileImageManagerService fileImageManagerService,
        IFileImageNameService fileImageNameService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _fileImageManagerService = fileImageManagerService;
        _fileImageNameService = fileImageNameService;
    }
    public async Task<Unit> Handle(AddCourseAdvertCommand request, CancellationToken cancellationToken)
    {
        var sessionId = Guid.NewGuid().ToString();

        if (request.ImageFile != null)
        {
            request.ImageUrl = _fileImageNameService.GetFileName(request.ImageFile.FileName, sessionId, _dateTimeService.Now);
            await _fileImageManagerService.UploadImageAsync(request.ImageFile, request.ImageUrl);
        }

        await AddToDatabase(request, sessionId, cancellationToken);

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
            CourseImage = string.IsNullOrWhiteSpace(request.ImageUrl) ? "course_default.jpg" : request.ImageUrl,
            Location = request.Location,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            CreationDate = _dateTimeService.Now,
            WebsiteUrl = SlugHelper.GenerateSlug(request.Title, request.Location, sessionId),
            UserId = request.UserId,
            CategoryId = request.CategoryId,

        };

        _context.CourseAdverts.Add(courseAdvert);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
