﻿using System.ComponentModel.DataAnnotations;

namespace LearningApp.Models.Entities;

public sealed class LectureTestQuestion : BaseEntity
{
    public int Id { get; set; }

    [Required]
    public int LectureTestId { get; set; }

    [Required]
    public string Question { get; set; } = null!;

    [Required]
    public int Order { get; set; }

    public string? Image { get; set; }

    public LectureTest? LectureTest { get; set; }
    public IEnumerable<LectureTestAnswer>? LectureTestAnswers { get; set; }
}
