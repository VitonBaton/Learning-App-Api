using System.ComponentModel.DataAnnotations;

namespace LearningApp.Models.Entities;

public sealed class ChapterTest : BaseEntity
{
    public int Id { get; set; }

    [Required]
    public int ChapterId { get; set; }

    [Required]
    public string Title { get; set; }

    public Chapter? Chapter { get; set; }
    public IEnumerable<ChapterTestQuestion>? ChapterTestQuestions { get; set; }
    public IEnumerable<ChapterTestResult>? ChapterTestResults { get; set; }
}
