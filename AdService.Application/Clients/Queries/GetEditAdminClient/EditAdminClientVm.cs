using AdService.Application.Clients.Commands.EditAdminClient;
using AdService.Application.Roles.Queries.GetRole;


namespace AdService.Application.Clients.Queries.GetEditAdminClient
{
    public class EditAdminClientVm
    {
        public EditAdminClientCommand Client { get; set; }

        public List<RoleDto> AvailableRoles { get; set; }
    }
}
