using AdService.Application.Advertisements.CourseAdvertisements.Commands.EditCourseAdvert;
using MediatR;


namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetEditCourseAdvert;

public class GetEditCourseAdvertQuery : IRequest<EditCourseAdvertVm>
{
    public string AdvertId { get; set; }    
}
