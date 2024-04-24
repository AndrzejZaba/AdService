using AdService.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AdService.Infrastructure.Services;

public class FileManagerService : IFileManagerService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileManagerService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task Upload(IFormFile file)
    {
        var folderRoot = Path.Combine(_webHostEnvironment.WebRootPath, "Content", "Files");

        if (!Directory.Exists(folderRoot))
            Directory.CreateDirectory(folderRoot);

        if (file == null)
            return;

        var filePath = Path.Combine(folderRoot, file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
    }
}
