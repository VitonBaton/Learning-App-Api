namespace LearningApp.Entities.DataTransferObjects;

public record ChapterCreateDto(string Title,
    string Description,
    int Order);
