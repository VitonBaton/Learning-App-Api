namespace LearningApp.Models.DataTransferObjects;

public sealed class LectureDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Order { get; set; }
    public DateTime CreatedAt { get; set; }
}
