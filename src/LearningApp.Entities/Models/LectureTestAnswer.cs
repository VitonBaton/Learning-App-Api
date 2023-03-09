using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record LectureTestAnswer
{
    public int Id { get; set; }

    [Required]
    public int LectureTestQuestionId { get; set; }

    [Required]
    public string Answer { get; set; } = null!;

    [Required]
    public DateTime CreatedAt { get; set; }

    public LectureTestQuestion? LectureTestQuestion { get; set; }
}