﻿using System.ComponentModel.DataAnnotations;

namespace LearningApp.Models.Entities;

public sealed class LectureTestAnswer : BaseEntity
{
    public int Id { get; set; }

    [Required]
    public int LectureTestQuestionId { get; set; }

    [Required]
    public string Answer { get; set; } = null!;

    [Required]
    public bool IsRight { get; set; }

    public LectureTestQuestion? LectureTestQuestion { get; set; }
}
