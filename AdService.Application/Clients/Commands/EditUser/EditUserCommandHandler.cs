using AdService.Application.Common.Interfaces;
using AdService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Clients.Commands.EditUser;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileImageManagerService _fileImageManagerService;
    private readonly IFileImageNameService _fileImageNameService;

    public EditUserCommandHandler(
        IApplicationDbContext context,
        IFileImageManagerService fileImageManagerService,
        IFileImageNameService fileImageNameService)
    {
        _context = context;
        _fileImageManagerService = fileImageManagerService;
        _fileImageNameService = fileImageNameService;
    }
    public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        if (request.IsPrivateAccount)
        {
            request.NipNumber = null;
            request.ComapnyName = null;
            request.LogoFile = null;
            request.LogoUrl = null;
        }

        if (request.LogoFile != null) 
        {
            request.LogoFile = _file
        }

        var user = await _context.Users
            .Include(x => x.Client)
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;

        if (user.Client == null)
            user.Client = new Client();

        user.Client.IsPrivateAccount = request.IsPrivateAccount;
        user.Client.NipNumber = request.NipNumber;
        user.Client.UserId = request.Id;
        user.Client.CompanyName = request.ComapnyName;

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
