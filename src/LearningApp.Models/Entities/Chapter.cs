using System.ComponentModel.DataAnnotations;

namespace LearningApp.Models.Entities;

public sealed record Chapter : BaseEntity
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public int Order { get; set; }

    public IEnumerable<Lecture>? Lectures { get; set; }
    public IEnumerable<ChapterTest>? ChapterTests { get; set; }
}


