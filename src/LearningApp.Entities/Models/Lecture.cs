using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record Lecture
{
    public int Id { get; set; }

    [Required]
    public int ChapterId { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Content { get; set; } = null!;

    [Required]
    public int Order { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }

    public Chapter? Chapter { get; set; }
    public IEnumerable<LectureTest>? Tests { get; set; }
}