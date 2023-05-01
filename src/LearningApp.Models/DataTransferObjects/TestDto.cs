namespace LearningApp.Models.DataTransferObjects;

public record TestDto(int Id,
    string Title,
    string Description,
    DateTime CreatedAt,
    IEnumerable<TestQuestionDto>? Questions);