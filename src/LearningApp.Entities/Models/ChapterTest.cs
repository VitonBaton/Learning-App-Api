using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record ChapterTest
{
    public int Id { get; set; }

    [Required]
    public int ChapterId { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime CreatedAt { get; set; }

    public Chapter? Chapter { get; set; }
    public IEnumerable<ChapterTestQuestion>? ChapterTestQuestions { get; set; }
}