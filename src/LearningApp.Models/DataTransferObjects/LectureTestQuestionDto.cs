namespace LearningApp.Models.DataTransferObjects;

public record LectureTestQuestionDto(int Id,
    string Question,
    int Order,
    DateTime CreatedAt,
    IEnumerable<string>? Answers);