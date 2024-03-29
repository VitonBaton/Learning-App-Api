﻿namespace LearningApp.Models.DataTransferObjects;

public sealed class LectureTestWithQuestionsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IEnumerable<TestQuestionDto> Questions { get; set; }
}
