using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public sealed record Chapter
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;
    
    [Required]
    public string Description { get; set; } = null!;
    
    [Required]
    public int Order { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public IEnumerable<Lecture>? Lectures { get; set; }
    public IEnumerable<ChapterTest>? ChapterTests { get; set; }
}


