namespace LearningApp.Models.DataTransferObjects;

public sealed class ChapterCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}
