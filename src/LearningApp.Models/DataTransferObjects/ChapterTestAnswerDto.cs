namespace LearningApp.Models.DataTransferObjects;

public sealed class ChapterTestAnswerDto
{
    public int Id { get; set; }
    public string Answer { get; set; }
    public DateTime CreatedAt { get; set; }
}
