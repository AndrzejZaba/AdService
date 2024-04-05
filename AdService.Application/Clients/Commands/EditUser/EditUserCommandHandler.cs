using AdService.Application.Common.Interfaces;
using AdService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Clients.Commands.EditUser;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
{
    private readonly IApplicationDbContext _context;

    public EditUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        if (request.IsPrivateAccount)
            request.NipNumber = null;

        var user = await _context.Users
            .Include(x => x.Client)
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;

        //if (user.Client == null)
        //    user.Client = new Client();

        //user.Client.IsPrivateAccount = request.IsPrivateAccount;
        //user.Client.NipNumber = request.NipNumber;
        //user.Client.UserId = request.Id;

        if (user.Address == null)
            user.Address = new Address();

        user.Address.Country = request.Country;
        user.Address.City = request.City;
        user.Address.Street = request.Street;
        user.Address.StreetNumber = request.StreetNumber;
        user.Address.ZipCode = request.ZipCode;
        user.Address.UserId = request.Id;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
