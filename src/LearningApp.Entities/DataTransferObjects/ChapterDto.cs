namespace LearningApp.Entities.DataTransferObjects;

public record ChapterDto(int Id,
    string Title,
    string Description,
    int Order,
    DateTime CreatedAt,
    IEnumerable<LectureDto>? Lectures);
    
    