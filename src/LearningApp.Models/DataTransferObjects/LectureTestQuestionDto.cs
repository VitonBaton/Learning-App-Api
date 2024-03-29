﻿namespace LearningApp.Models.DataTransferObjects;

public sealed class LectureTestQuestionDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public int Order { get; set; }
    public IEnumerable<string> Answers { get; set; }
}
