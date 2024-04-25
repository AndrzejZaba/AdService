using Microsoft.AspNetCore.Http;


namespace AdService.Application.Common.Interfaces;

public interface IFileImageManagerService
{
    Task UploadImage(IFormFile file, string fileName);
}
