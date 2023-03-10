namespace LearningApp.Entities.DataTransferObjects;

public record ChapterWithTestsDto(int Id,
    string Title,
    string Description,
    int Order,
    DateTime CreatedAt,
    IEnumerable<TestDto>? Tests);