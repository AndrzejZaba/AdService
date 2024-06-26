﻿using AdService.Application.Clients.Commands.EditUser;
using AdService.Application.Common.Interfaces;
using AdService.Application.Users.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Clients.Queries.GetClient;

public class GetClientQueryHandler : IRequestHandler<GetClientQuery, EditUserCommand>
{
    private readonly IApplicationDbContext _context;

    public GetClientQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditUserCommand> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        var user = await _context
            .Users
            .Include(x => x.Client)
            .Include(x => x.Address)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.UserId);

        return user.ToEditUserCommand();
            
    }
}
