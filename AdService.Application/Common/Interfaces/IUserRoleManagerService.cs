using AdService.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdService.Application.Common.Interfaces
{
    public interface IUserRoleManagerService
    {
        Task<IEnumerable<ApplicationUser>> GetUsersInRoleAsync(string roleName);
        Task<IEnumerable<IdentityRole>> GetRolesAsync(string userId);
        Task RemoveFromRolesAsync(string userId, string name);
        Task AddToRoleAsync(string userId, string name);
    }
}
