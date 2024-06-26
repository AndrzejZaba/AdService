﻿using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdService.Application.Advertisements.CourseAdvertisements.Commands.AddCourseAdvert;

public class AddCourseAdvertCommand : IRequest
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

    [Required(ErrorMessage = "Category is required.")]
    [DisplayName("Category")]
    public int CategoryId { get; set; }
    public string UserId { get; set; }

    [Required(ErrorMessage = "Choose advertisement start date")]
    [DisplayName("Start advertising from...")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Choose advertisement end date")]
    [DisplayName("Display advertismenet untill...")]
    public DateTime EndDate { get; set; }

    [DisplayName("Upload image related to your course.")]
    public IFormFile ImageFile { get; set; }

    [DisplayName("Course Image")]
    public string ImageUrl { get; set; }
}
