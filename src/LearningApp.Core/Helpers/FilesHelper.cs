using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Http;

namespace LearningApp.Core.Helpers;

public static class FilesHelper
{
    public const string BaseImagesPath = "Images";
    public const string BaseWordPath = "Documents";

    public static async Task<string> SaveImageFile(IFormFile file)
    {
        if (!Directory.Exists(BaseImagesPath))
        {
            Directory.CreateDirectory(BaseImagesPath);
        }

        var extension = Path.HasExtension(file.FileName) ? Path.GetExtension(file.FileName) : ".png";
        var filename = Guid.NewGuid() + extension;
        var path = BaseImagesPath + '/' + filename;
        await using var fileStream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(fileStream);

        return filename;
    }

    public static void DeleteImageFile(string imagePath)
    {
        var path = BaseImagesPath + '/' + imagePath;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static void DeleteWordFile(string imagePath)
    {
        var path = BaseWordPath + '/' + imagePath;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static async Task<string> SaveWordFile(IFormFile file)
    {
        if (!Directory.Exists(BaseWordPath))
        {
            Directory.CreateDirectory(BaseWordPath);
        }

        var extension = Path.HasExtension(file.FileName) ? Path.GetExtension(file.FileName) : ".docx";
        var filename = Guid.NewGuid() + extension;
        var path = BaseWordPath + '/' + filename;
        await using var fileStream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(fileStream);

        return path;
    }

    public static string ReadDocxFileText(string filepath)
    {
        using var wordDocument =
            WordprocessingDocument.Open(filepath, false);
        if (wordDocument.MainDocumentPart is null)
        {
            return string.Empty;
        }

        var body = wordDocument.MainDocumentPart.Document.Body;
        return body is null ? string.Empty : body.InnerText;
    }

    public static bool IsImage(IFormFile file)
    {
        var contentType = file.ContentType;
        return contentType.StartsWith("image");
    }

    public static bool IsWordFile(IFormFile file)
    {
        var wordContentTypes = new[]
        {
            "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
        };

        var contentType = file.ContentType;

        return wordContentTypes.Contains(contentType, StringComparer.OrdinalIgnoreCase);
    }

    public static Stream GetFileStream(string filePath)
    {
        return new FileStream(filePath, FileMode.Open);
    }
}
