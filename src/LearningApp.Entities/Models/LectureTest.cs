using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record LectureTest : BaseEntity
{
    public int Id { get; set; }

    [Required]
    public int LectureId { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    public Lecture? Lecture { get; set; }
    public IEnumerable<LectureTestQuestion>? LectureTestQuestions { get; set; }
}
