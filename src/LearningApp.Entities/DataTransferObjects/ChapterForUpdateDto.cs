namespace LearningApp.Entities.DataTransferObjects;

public record ChapterForUpdateDto(string Title,
    string Description,
    int Order);