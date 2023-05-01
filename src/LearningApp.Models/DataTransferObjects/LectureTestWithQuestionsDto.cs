namespace LearningApp.Models.DataTransferObjects;

public record LectureTestWithQuestionsDto(int Id,
    string Title,
    string Description,
    DateTime CreatedAt,
    IEnumerable<TestQuestionDto>? Questions);