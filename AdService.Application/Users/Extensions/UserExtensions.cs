using AdService.Application.Advertisements.CourseAdvertisements.Queries.GetCourseAdvertPage;
using AdService.Application.Clients.Commands.EditAdminClient;
using AdService.Application.Clients.Commands.EditUser;
using AdService.Application.Clients.Queries.GetClient;
using AdService.Application.Clients.Queries.GetClients;
using AdService.Domain.Entities;

namespace AdService.Application.Users.Extensions;

public static class UserExtensions
{

    //public static ClientDto ToClientDto(this ApplicationUser user)
    //{
    //    if (user == null)
    //        return null;

    //    return new ClientDto
    //    {
    //        Id = user.Id,
    //        City = user.Address?.City,
    //        Country = user.Address?.Country,
    //        Street = user.Address?.Street,
    //        StreetNumber = user.Address?.StreetNumber,
    //        ZipCode = user.Address?.ZipCode,
    //        Email = user.Email,
    //        FirstName = user.FirstName,
    //        LastName = user.LastName,
    //        PhoneNumber = user.PhoneNumber,
    //        NipNumber = user.Client?.NipNumber,
    //        IsBusinessAccount = user.Client?.IsBusinessAccount ?? true
    //    };
    //}

    public static ClientBasicsDto ToClientBasicsDto(this ApplicationUser user)
    {
        if (user == null)
            return null;

        return new ClientBasicsDto
        {
            Id = user.Id,
            Name = !string.IsNullOrWhiteSpace(user.FirstName) ||
                   !string.IsNullOrWhiteSpace(user.LastName)
                   ? $"{user.FirstName} {user.LastName}" : "-",
            Email = user.Email,
            //IsBusinessAccount = user.Client.IsBusinessAccount,
            IsDeleted = user.IsDeleted
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
            IsBusinessAccount = user.Client?.IsBusinessAccount ?? false,
            CompanyName = user.Client?.CompanyName
        };
    }

    public static EditAdminClientCommand ToEditAdminClientCommand(this ApplicationUser user)
    {
        if (user == null)
            return null;

        return new EditAdminClientCommand
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
            IsBusinessAccount = user.Client?.IsBusinessAccount ?? false,
            CompanyName = user.Client?.CompanyName

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
            IsBusinessAccount = user.Client?.IsBusinessAccount ?? true,
            CompanyName = user.Client?.CompanyName,
            CompanyLogo = user.Client?.CompanyLogo
        };
    }
}
