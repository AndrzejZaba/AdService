using MediatR;

namespace AdService.Application.Advertisements.CourseAdvertisements.Commands;

public class AddCourseAdvertisementCommandHandler : IRequestHandler<AddCourseAdvertisementCommand>
{
    public async Task<Unit> Handle(AddCourseAdvertisementCommand request, CancellationToken cancellationToken)
    {
        await Task.FromResult(0);
        //throw new NotImplementedException();
        return Unit.Value;
    }
}
