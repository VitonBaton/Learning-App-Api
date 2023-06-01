namespace LearningApp.Models.DataTransferObjects;

public sealed class PassedTestDto
{
    public IEnumerable<PassedQuestionDto> Questions { get; set; }
    public int CompletionTimeInSeconds { get; set; }
}
