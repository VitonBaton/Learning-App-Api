namespace LearningApp.Models.DataTransferObjects;

public sealed class TestDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<TestQuestionDto> Questions { get; set; }
}
