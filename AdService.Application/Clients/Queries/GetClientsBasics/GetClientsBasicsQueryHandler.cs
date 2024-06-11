using AdService.Application.Clients.Queries.GetClients;
using AdService.Application.Common.Interfaces;
using AdService.Application.Dictionaries;
using AdService.Application.Users.Extensions;
using MediatR;

namespace AdService.Application.Clients.Queries.GetClientsBasics;

public class GetClientsBasicsQueryHandler : IRequestHandler<GetClientsBasicsQuery, IEnumerable<ClientBasicsDto>>
{
    private readonly IUserRoleManagerService _userRoleManagerService;

    public GetClientsBasicsQueryHandler(IUserRoleManagerService userRoleManagerService)
    {
        _userRoleManagerService = userRoleManagerService;
    }
    public async Task<IEnumerable<ClientBasicsDto>> Handle(GetClientsBasicsQuery request, CancellationToken cancellationToken)
    {
        var clients = (await _userRoleManagerService
            .GetUsersInRoleAsync(RolesDict.Client))
            .Select(x => x.ToClientBasicsDto());

        return clients;
    }
}
