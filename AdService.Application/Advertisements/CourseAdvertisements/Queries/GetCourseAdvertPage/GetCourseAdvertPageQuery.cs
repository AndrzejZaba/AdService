using MediatR;


namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetCourseAdvertPage;

public class GetCourseAdvertPageQuery : IRequest<CourseAdvertPageVm>
{
    public string Url { get; set; }
    public string UserId { get; set; }
}
