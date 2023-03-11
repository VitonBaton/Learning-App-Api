using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record ChapterTestAnswer : BaseEntity
{
    public int Id { get; set; }

    [Required]
    public int ChapterTestQuestionId { get; set; }

    [Required]
    public string Answer { get; set; } = null!;

    public ChapterTestQuestion? ChapterTestQuestion { get; set; }
}
