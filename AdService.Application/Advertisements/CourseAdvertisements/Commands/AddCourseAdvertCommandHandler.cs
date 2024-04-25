using AdService.Application.Common.Helpers;
using AdService.Application.Common.Interfaces;
using AdService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AdService.Application.Advertisements.CourseAdvertisements.Commands;

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

        request.ImageUrl = _fileImageNameService.GetFileName(request.ImageFile.FileName, request.UserId, _dateTimeService.Now);

        await _fileImageManagerService.UploadImage(request.ImageFile, filename);

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
            CourseImage = String.IsNullOrWhiteSpace(request.ImageUrl) ? "course_default.jpg" : request.ImageUrl,
            Location = request.Location,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            CreationDate = _dateTimeService.Now,
            WebsiteUrl = SlugHelper.GenerateSlug(request.Title, request.Location, sessionId)
        };

    }
}
