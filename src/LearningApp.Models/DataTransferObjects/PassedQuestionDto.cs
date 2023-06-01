namespace LearningApp.Models.DataTransferObjects;

public sealed class PassedQuestionDto
{
    public int Id { get; set; }
    public IEnumerable<string> Answers { get; set; }
}
