namespace LearningApp.Models.DataTransferObjects;

public record ChapterCreateDto(string Title,
    string Description,
    int Order);
