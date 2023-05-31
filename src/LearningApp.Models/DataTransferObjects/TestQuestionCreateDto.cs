namespace LearningApp.Models.DataTransferObjects;

public sealed class TestQuestionCreateDto
{
    public string Question { get; set; } = null!;

    public int Order { get; set; }

    public string? Image { get; set; }

    public IEnumerable<TestAnswerCreateDto>? TestAnswers { get; set; }
}
