namespace LearningApp.Models.DataTransferObjects;

public sealed class TestResultDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Attempt { get; set; }

    public int RightAnswers { get; set; }

    public int QuestionsCount { get; set; }

    public int CompletionTimeInSeconds { get; set; }
}
