using AdService.Application.Roles.Queries.GetRole;


namespace AdService.Application.Common.Interfaces;

public interface IRoleManagerService
{
    IEnumerable<RoleDto> GetRoles();
}
