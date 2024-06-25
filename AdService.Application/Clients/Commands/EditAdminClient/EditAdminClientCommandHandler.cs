using AdService.Application.Common.Extensions;
using AdService.Application.Common.Interfaces;
using AdService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Clients.Commands.EditAdminClient;

public class EditAdminClientCommandHandler : IRequestHandler<EditAdminClientCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IUserRoleManagerService _userRoleManagerService;
    private readonly IRoleManagerService _roleManagerService;
    private readonly IFileImageNameService _fileImageNameService;
    private readonly IFileImageManagerService _fileImageManagerService;
    private readonly IDateTimeService _dateTimeService;

    public EditAdminClientCommandHandler(
        IApplicationDbContext context, 
        IUserRoleManagerService userRoleManagerService,
        IRoleManagerService roleManagerService,
        IFileImageNameService fileImageNameService,
        IFileImageManagerService fileImageManagerService,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _userRoleManagerService = userRoleManagerService;
        _roleManagerService = roleManagerService;
        _fileImageNameService = fileImageNameService;
        _fileImageManagerService = fileImageManagerService;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(EditAdminClientCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsBusinessAccount)
        {
            request.NipNumber = null;
            request.CompanyName = null;
            request.CompanyLogo = null;
            request.LogoUrl = null;
        }

        if (request.LogoFile != null)
        {
            request.LogoUrl = _fileImageNameService.GetFileName(request.LogoFile.FileName, request.CompanyName, _dateTimeService.Now);
            await _fileImageManagerService.UploadLogoAsync(request.LogoFile, request.LogoUrl);
        }

        var user = await _context.Users
            .Include(x => x.Address)
            .Include(x => x.Client)
            .FirstOrDefaultAsync(x => x.Id ==  request.Id);

        user.Email = request.Email;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;

        if (user.Client == null)
            user.Client = new Client();

        user.Client.IsBusinessAccount = request.IsBusinessAccount;
        user.Client.NipNumber = request.NipNumber;
        user.Client.CompanyName = request.CompanyName;
        user.Client.CompanyLogo = request.CompanyLogo;
        user.Client.UserId = request.Id;

        if(user.Address == null)
            user.Address = new Address();

        user.Address.Country = request.Country;
        user.Address.City = request.City;
        user.Address.Street = request.Street;
        user.Address.StreetNumber = request.StreetNumber;
        user.Address.ZipCode = request.ZipCode;
        user.Address.UserId = request.Id;

        await _context.SaveChangesAsync(cancellationToken);

        if(request.RoleIds != null && request.RoleIds.Any())
        {
            await UpdateRoles(request.RoleIds, request.Id);
        }

        return Unit.Value;
    }

    private async Task UpdateRoles(List<string> newRolesIds, string userId)
    {
        var roles = _roleManagerService.GetRoles()
            .Select(x => new IdentityRole { Id = x.Id, Name = x.Name });

        var oldRoles = await GetOldRoles(userId);
        var newRoles = GetNewRoles(newRolesIds, roles);

        await RemoveRoles(userId, oldRoles, newRoles);

        await AddNewRoles(userId, oldRoles, newRoles);
    }

    private async Task AddNewRoles(string userId, List<IdentityRole> oldRoles, List<IdentityRole> newRoles)
    {
        var rolesToAdd = newRoles.Except(oldRoles, x => x.Id);

        foreach (var role in rolesToAdd)
            await _userRoleManagerService.AddToRoleAsync(userId, role.Name);
    }

    private async Task RemoveRoles(string userId, List<IdentityRole> oldRoles, List<IdentityRole> newRoles)
    {
        var rolesToRemove = oldRoles.Except(newRoles, x => x.Id);

        foreach (var role in rolesToRemove)
            await _userRoleManagerService.RemoveFromRolesAsync(userId, role.Name);
    }

    private List<IdentityRole> GetNewRoles(List<string> newRolesIds, IEnumerable<IdentityRole> roles)
    {
        var newRoles = new List<IdentityRole>();

        foreach (var roleId in newRolesIds) 
        {
            newRoles.Add(new IdentityRole { Id = roleId, Name = roles.FirstOrDefault(x=> x.Id == roleId).Name });
        }

        return newRoles;
    }

    private async Task<List<IdentityRole>> GetOldRoles(string userId)
    {
        return (await _userRoleManagerService.GetRolesAsync(userId)).ToList();
    }
}
