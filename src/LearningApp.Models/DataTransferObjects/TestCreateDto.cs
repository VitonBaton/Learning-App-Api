namespace LearningApp.Models.DataTransferObjects;

public sealed class TestCreateDto
{
    public int ParentId { get; set; }

    public string Title { get; set; }

    public IEnumerable<TestQuestionCreateDto>? TestQuestions { get; set; }
}
