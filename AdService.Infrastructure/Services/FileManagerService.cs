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
    public async Task UploadImage(IFormFile file, string fileName)
    {
        var folderRoot = Path.Combine(_webHostEnvironment.WebRootPath, "Content", "Images");

        if (!Directory.Exists(folderRoot))
            Directory.CreateDirectory(folderRoot);

        if (file == null)
            return;

        var filePath = Path.Combine(folderRoot, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
    }
}
