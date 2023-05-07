using System.ComponentModel.DataAnnotations;

namespace LearningApp.Models.Entities;

public sealed class ChapterTestResult : BaseEntity
{
    [Required]
    public int ChapterTestId { get; set; }

    public ChapterTest? ChapterTest { get; set; }

    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int Attempt { get; set; }

    [Required]
    public int RightAnswers { get; set; }

    [Required]
    public int QuestionsCount { get; set; }

    public User? User { get; set; }
}
