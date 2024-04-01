using MediatR;

namespace AdService.Application.Clients.Queries.GetClient;

public class GetClientQuery : IRequest<ClientDto>
{
    public string UserId { get; set; }
}
