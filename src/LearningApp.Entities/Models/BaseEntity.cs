using System.ComponentModel.DataAnnotations;

namespace LearningApp.Entities.Models;

public record BaseEntity
{
    [Required]
    public DateTime CreatedAt { get; set; }
}
