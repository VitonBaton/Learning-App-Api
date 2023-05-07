using LearningApp.Models.DataTransferObjects;

namespace LearningApp.Contracts.Services;

public interface IChaptersService
{
    Task<IEnumerable<ChapterDto>> GetAllChaptersAsync();
    Task<ChapterWithTestsDto?> GetChapterWithTests(int id);
    Task<ChapterDto?> GetChapterWithLectures(int id);
    Task<IEnumerable<ChapterTestWithQuestionsDto>> GetTestsForChapter(int chapterId);
    Task<ChapterDto> CreateChapter(ChapterCreateDto chapter);
    Task UpdateChapter(int id, ChapterCreateDto chapter);
    Task DeleteChapter(int id);
}

