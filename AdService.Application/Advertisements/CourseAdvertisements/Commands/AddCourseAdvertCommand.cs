using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdService.Application.Advertisements.CourseAdvertisements.Commands;

public class AddCourseAdvertisementCommand : IRequest
{
    [Required(ErrorMessage = "Course's Title is required.")]
    [DisplayName("Title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Course's Description is required.")]
    [DisplayName("Describe your course...")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Location is required.")]
    [DisplayName("What's your course location...")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Course's Price is required.")]
    [DisplayName("Course's Price")]
    public decimal CoursePrice { get; set; }
    
    [DisplayName("Price to pay for advertisement")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Choose advertisement start date")]
    [DisplayName("Start advertising from...")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Choose advertisement end date")]
    [DisplayName("Display advertismenet untill...")]
    public DateTime EndDate { get; set; }

    [DisplayName("Upload images related to your course.")]
    public IEnumerable<IFormFile> Images { get; set; }
}
