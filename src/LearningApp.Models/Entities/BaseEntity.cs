using System.ComponentModel.DataAnnotations;

namespace LearningApp.Models.Entities;

public record BaseEntity
{
    [Required]
    public DateTime CreatedAt { get; set; }
}
