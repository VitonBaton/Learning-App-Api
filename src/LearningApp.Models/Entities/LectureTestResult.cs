using System.ComponentModel.DataAnnotations;

namespace LearningApp.Models.Entities;

public sealed class LectureTestResult : BaseEntity
{
    [Required]
    public int LectureTestId { get; set; }

    public LectureTest? LectureTest { get; set; }

    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int Attempt { get; set; }

    [Required]
    public int RightAnswers { get; set; }

    [Required]
    public int QuestionsCount { get; set; }

    [Required]
    public int CompletionTimeInSeconds { get; set; }

    public User? User { get; set; }
};
