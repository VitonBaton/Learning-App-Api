using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record LectureTest
{
    public int Id { get; set; }

    [Required]
    public int LectureId { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime CreatedAt { get; set; }

    public Lecture? Lecture { get; set; }
    public IEnumerable<LectureTestQuestion>? LectureTestQuestions { get; set; }
}