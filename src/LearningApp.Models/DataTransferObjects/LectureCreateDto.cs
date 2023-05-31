namespace LearningApp.Models.DataTransferObjects;

public sealed class LectureCreateDto
{
    public int ChapterId { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }
}
