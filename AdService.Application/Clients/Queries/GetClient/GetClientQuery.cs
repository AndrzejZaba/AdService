using AdService.Application.Clients.Commands.EditUser;
using MediatR;

namespace AdService.Application.Clients.Queries.GetClient;

public class GetClientQuery : IRequest<EditUserCommand>
{
    public string UserId { get; set; }
}
