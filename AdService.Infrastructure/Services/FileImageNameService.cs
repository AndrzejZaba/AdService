using AdService.Application.Common.Interfaces;

namespace AdService.Infrastructure.Services;

public class FileImageNameService : IFileImageNameService
{
    public string GetFileName(string fileName, string id, DateTime creationDateTime)
    {
        var extension = Path.GetExtension(fileName);
        var timestamp = creationDateTime.ToString("yyyyMMddmmss");

        return $"img_{id}_{timestamp}{extension}";
    }
}
