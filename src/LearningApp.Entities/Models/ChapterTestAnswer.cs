using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record ChapterTestAnswer
{
    public int Id { get; set; }

    [Required]
    public int ChapterTestQuestionId { get; set; }

    [Required]
    public string Answer { get; set; } = null!;

    [Required]
    public DateTime CreatedAt { get; set; }

    public ChapterTestQuestion? ChapterTestQuestion { get; set; }
}