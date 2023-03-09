using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record LectureTestQuestion
{
    public int Id { get; set; }

    [Required]
    public int LectureTestId { get; set; }

    [Required]
    public string Question { get; set; } = null!;

    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    public int Order { get; set; }

    public LectureTest? LectureTest { get; set; }
    public IEnumerable<LectureTestAnswer>? LectureTestAnswers { get; set; }
}