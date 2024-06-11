using MediatR;

namespace AdService.Application.Clients.Queries.GetClients;

public class GetClientsBasicsQuery : IRequest<IEnumerable<ClientBasicsDto>>
{
}
