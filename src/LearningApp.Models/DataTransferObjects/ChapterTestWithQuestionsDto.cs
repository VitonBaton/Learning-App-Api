namespace LearningApp.Models.DataTransferObjects;

public record ChapterTestWithQuestionsDto(int Id,
    string Title,
    string Description,
    DateTime CreatedAt,
    IEnumerable<TestQuestionDto>? Questions);