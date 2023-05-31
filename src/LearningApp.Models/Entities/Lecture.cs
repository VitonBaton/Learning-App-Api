using System.ComponentModel.DataAnnotations;

namespace LearningApp.Models.Entities;

public sealed class Lecture : BaseEntity
{
    public int Id { get; set; }

    [Required]
    public int ChapterId { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    public string? ContentPath { get; set; }

    [Required]
    public int Order { get; set; }

    public Chapter? Chapter { get; set; }
    public IEnumerable<LectureTest>? Tests { get; set; }
}
