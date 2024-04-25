using AdService.Application.Common.Interfaces;

namespace AdService.Infrastructure.Services;

public class FileImageNameService : IFileImageNameService
{
    public string GetFileName(string fileName, string userId, DateTime creationDateTime)
    {
        var extension = Path.GetExtension(fileName);
        var timestamp = creationDateTime.ToString("yyyyMMddmmss");

        return $"img_{userId}_{timestamp}{extension}";
    }
}
