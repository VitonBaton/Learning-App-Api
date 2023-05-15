using DocumentFormat.OpenXml.Packaging;
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
}
