using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record LectureTestAnswer : BaseEntity
{
    public int Id { get; set; }

    [Required]
    public int LectureTestQuestionId { get; set; }

    [Required]
    public string Answer { get; set; } = null!;

    public LectureTestQuestion? LectureTestQuestion { get; set; }
}
