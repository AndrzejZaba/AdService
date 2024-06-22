using AdService.Domain.Entities;


namespace AdService.Application.Common.Interfaces
{
    public interface IUserRoleManagerService
    {
        Task<IEnumerable<ApplicationUser>> GetUsersInRoleAsync(string roleName);
        Task<IEnumerable<IdentityRole>> GetRolesAsync(string userId);
    }
}
