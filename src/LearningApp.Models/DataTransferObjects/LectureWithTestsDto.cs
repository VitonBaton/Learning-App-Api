namespace LearningApp.Models.DataTransferObjects;

public sealed class LectureWithTestsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? ContentPath { get; set; }
    public int Order { get; set; }
    public IEnumerable<SimpleTestDto>? Tests { get; set; }
}
