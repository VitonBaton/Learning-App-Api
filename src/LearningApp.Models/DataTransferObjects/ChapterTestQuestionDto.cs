namespace LearningApp.Models.DataTransferObjects;

public record ChapterTestQuestionDto(int Id,
    string Question,
    int Order,
    DateTime CreatedAt,
    IEnumerable<string>? Answers);