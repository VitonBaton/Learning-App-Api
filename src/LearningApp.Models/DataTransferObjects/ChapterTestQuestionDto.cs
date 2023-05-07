namespace LearningApp.Models.DataTransferObjects;

public sealed class ChapterTestQuestionDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public int Order { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<string> Answers { get; set; }
}
