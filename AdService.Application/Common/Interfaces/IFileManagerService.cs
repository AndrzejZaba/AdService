using Microsoft.AspNetCore.Http;


namespace AdService.Application.Common.Interfaces;

public interface IFileImageManagerService
{
    Task UploadImageAsync(IFormFile file, string fileName);
    Task UploadLogoAsync(IFormFile file, string fileName);
    Task UploadAsync(IFormFile file, string path, string filename);
}
