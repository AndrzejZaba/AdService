using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdService.Application.Advertisements.CourseAdvertisements.Commands.EditCourseAdvert;

public class EditCourseAdvertCommand : IRequest
{
    [Required(ErrorMessage = "Course's Title is required.")]
    [DisplayName("Edit course's title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Course's Description is required.")]
    [DisplayName("Edit your course's description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Location is required.")]
    [DisplayName("Edit course's location")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Course's Price is required.")]
    [DisplayName("Edit course's price")]
    public decimal CoursePrice { get; set; }

    [DisplayName("Price to pay for advertisement's update")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    [DisplayName("Category")]
    public int CategoryId { get; set; }
    public string UserId { get; set; }

    [Required(ErrorMessage = "Choose advertisement start date")]
    [DisplayName("Advertisement starts from...")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Choose advertisement end date")]
    [DisplayName("Extend end date (requires additional payment)")]
    public DateTime EndDate { get; set; }

    [DisplayName("Upload image related to your course.")]
    public IFormFile ImageFile { get; set; }

    [DisplayName("Course Image")]
    public string ImageUrl { get; set; }
}
