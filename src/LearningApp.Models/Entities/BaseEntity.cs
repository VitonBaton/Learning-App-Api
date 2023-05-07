using System.ComponentModel.DataAnnotations;

namespace LearningApp.Models.Entities;

public class BaseEntity
{
    [Required]
    public DateTime CreatedAt { get; set; }
}
