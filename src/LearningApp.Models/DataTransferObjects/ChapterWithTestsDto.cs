﻿namespace LearningApp.Models.DataTransferObjects;

public sealed class ChapterWithTestsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<TestDto> Tests { get; set; }
}
