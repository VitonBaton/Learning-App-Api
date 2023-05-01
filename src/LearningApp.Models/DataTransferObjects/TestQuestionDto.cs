namespace LearningApp.Models.DataTransferObjects;

public record TestQuestionDto(int Id,
    string Question,
    int Order,
    DateTime CreatedAt,
    IEnumerable<string>? Answers);