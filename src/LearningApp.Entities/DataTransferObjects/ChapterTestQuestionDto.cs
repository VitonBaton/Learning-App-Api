namespace LearningApp.Entities.DataTransferObjects;

public record ChapterTestQuestionDto(int Id,
    string Question,
    int Order,
    DateTime CreatedAt,
    IEnumerable<string>? Answers);