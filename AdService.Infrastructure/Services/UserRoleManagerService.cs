﻿using AdService.Application.Common.Interfaces;
using AdService.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdService.Infrastructure.Services;

public class UserRoleManagerService : IUserRoleManagerService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRoleManagerService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IEnumerable<IdentityRole>> GetRolesAsync(string userId)
    {
        var roles = new List<IdentityRole>();
        var user = await _userManager.FindByIdAsync(userId);
        var roleNames = await _userManager.GetRolesAsync(user);

        foreach (var role in roleNames)
            roles.Add(await _roleManager.FindByNameAsync(role));

        return roles;
    }

    public async Task<IEnumerable<ApplicationUser>> GetUsersInRoleAsync(string roleName)
    {
        return await _userManager.GetUsersInRoleAsync(roleName);
    }
}