using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record ChapterTestQuestion
{
    public int Id { get; set; }

    [Required]
    public int ChapterTestId { get; set; }

    [Required]
    public string Question { get; set; } = null!;

    [Required]
    public int Order { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }

    public ChapterTest? ChapterTest { get; set; }
    public IEnumerable<ChapterTestAnswer>? ChapterTestAnswers { get; set; }
}