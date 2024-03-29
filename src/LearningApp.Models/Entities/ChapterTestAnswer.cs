﻿using System.ComponentModel.DataAnnotations;

namespace LearningApp.Models.Entities;

public sealed class ChapterTestAnswer : BaseEntity
{
    public int Id { get; set; }

    [Required]
    public int ChapterTestQuestionId { get; set; }

    [Required]
    public string Answer { get; set; } = null!;

    [Required]
    public bool IsRight { get; set; }

    public ChapterTestQuestion? ChapterTestQuestion { get; set; }
}
