namespace LearningApp.Models.DataTransferObjects;

public record ChapterDto(int Id,
    string Title,
    string Description,
    int Order,
    DateTime CreatedAt,
    IEnumerable<LectureDto>? Lectures);
    
    