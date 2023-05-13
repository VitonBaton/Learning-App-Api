using Microsoft.AspNetCore.Http;

namespace LearningApp.Core.Helpers;

public static class FilesHelper
{
    public const string BasePath = "Images";

    public static async Task<string> SaveFile(IFormFile file)
    {
        var extension = Path.HasExtension(file.FileName) ? Path.GetExtension(file.FileName) : ".png";
        var path = BasePath + '/' + Guid.NewGuid() + extension;
        await using var fileStream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(fileStream);

        return path;
    }
}
