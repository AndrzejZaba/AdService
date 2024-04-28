using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetCourseAdvertPage;
using AdService.Application.Clients.Commands.EditUser;
using AdService.Application.Clients.Queries.GetClient;
using AdService.Domain.Entities;

namespace AdService.Application.Users.Extensions;

public static class UserExtensions
{

    public static ClientDto ToClientDto(this ApplicationUser user)
    {
        if (user == null)
            return null;

        return new ClientDto
        {
            Id = user.Id,
            City = user.Address?.City,
            Country = user.Address?.Country,
            Street = user.Address?.Street,
            StreetNumber = user.Address?.StreetNumber,
            ZipCode = user.Address?.ZipCode,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            NipNumber = user.Client?.NipNumber,
            IsPrivateAccount = user.Client?.IsPrivateAccount ?? true
        };
    }
    
    public static EditUserCommand ToEditUserCommand(this ApplicationUser user)
    {
        if (user == null)
            return null;

        return new EditUserCommand
        {
            Id = user.Id,
            City = user.Address?.City,
            Country = user.Address?.Country,
            Street = user.Address?.Street,
            StreetNumber = user.Address?.StreetNumber,
            ZipCode = user.Address?.ZipCode,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            NipNumber = user.Client?.NipNumber,
            IsPrivateAccount = user.Client?.IsPrivateAccount ?? true
        };
    }

    public static UserCourseAdvertPageDto ToUserCourseAdvertPageDto(this ApplicationUser user)
    {
        if (user == null)
            return null;

        return new UserCourseAdvertPageDto
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            NipNumber = user.Client?.NipNumber,
            IsPrivateAccount = user.Client?.IsPrivateAccount ?? true,
            CompanyName = user.Client?.CompanyName,
            CompanyLogo = user.Client?.CompanyLogo
        };
    }
}
