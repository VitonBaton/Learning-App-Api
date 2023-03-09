namespace LearningApp.Entities.DataTransferObjects;

public record TestQuestionDto(int Id,
    string Question,
    int Order,
    DateTime CreatedAt,
    IEnumerable<string>? Answers);