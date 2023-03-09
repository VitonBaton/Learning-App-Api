namespace LearningApp.Entities.DataTransferObjects;

public record LectureDto(int Id,  string Title, string Content, int Order, DateTime CreatedAt);