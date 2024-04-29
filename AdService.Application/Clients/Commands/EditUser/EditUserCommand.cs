using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AdService.Application.Clients.Commands.EditUser;

public class EditUserCommand : IRequest
{
    public string Id { get; set; }

    [Required(ErrorMessage = "Field 'Email' is required.")]
    [DisplayName("Email")]
    [EmailAddress(ErrorMessage = "Filed 'Email' isn't a proper email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Field 'First name' is required.")]
    [DisplayName("First name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Field 'Last name' is required.")]
    [DisplayName("Last name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Field 'Phone number' is required.")]
    [DisplayName("Phone number")]
    public string PhoneNumber { get; set; }

    //[Required(ErrorMessage = "Field 'Is private account' is required.")]
    [DisplayName("Is it business account?")]
    public bool IsBusinessAccount { get; set; }

    //[Required(ErrorMessage = "Field 'Nip number' is required.")]
    [DisplayName("Nip number")]
    public string NipNumber { get; set; }

    [DisplayName("Company Name")]
    public string CompanyName { get; set; }

    [DisplayName("Upload your company logo.")]
    public IFormFile LogoFile { get; set; }
    public string LogoUrl { get; set; }


    [Required(ErrorMessage = "Field 'Country' is required.")]
    [DisplayName("Country")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Field 'City' is required.")]
    [DisplayName("City")]
    public string City { get; set; }

    [Required(ErrorMessage = "Field 'Street' is required.")]
    [DisplayName("Street")]
    public string Street { get; set; }

    [Required(ErrorMessage = "Field 'Street number' is required.")]
    [DisplayName("Street number")]
    public string StreetNumber { get; set; }

    [Required(ErrorMessage = "Field 'Zip code' is required.")]
    [DisplayName("Zip code")]
    public string ZipCode { get; set; }
}
