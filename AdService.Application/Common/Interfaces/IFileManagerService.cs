using Microsoft.AspNetCore.Http;


namespace AdService.Application.Common.Interfaces;

public interface IFileManagerService
{
    Task Upload(IFormFile file);
}
