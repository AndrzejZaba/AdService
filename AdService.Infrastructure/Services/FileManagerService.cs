using AdService.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AdService.Infrastructure.Services;

public class FileImageManagerService : IFileImageManagerService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileImageManagerService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task UploadImageAsync(IFormFile file, string fileName)
    {
        var folderImages = Path.Combine(_webHostEnvironment.WebRootPath, "Content", "Images");

        await UploadAsync(file, folderImages, fileName);
    }

    public async Task UploadLogoAsync(IFormFile file, string fileName)
    {
        var folderLogos = Path.Combine(_webHostEnvironment.WebRootPath, "Content", "Images", "Logos");

        await UploadAsync(file, folderLogos, fileName);
    }

    public async Task UploadAsync(IFormFile file, string path, string fileName)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        if (file == null)
            return;

        var filePath = Path.Combine(path, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
    }
}
