using LearningApp.Entities.DataTransferObjects;

namespace LearningApp.Contracts.Services;

public interface IChaptersService
{
    Task<IEnumerable<ChapterDto>> GetAllChaptersAsync();
    Task<ChapterWithTestsDto?> GetChapterWithTests(int id);
    Task<ChapterDto?> GetChapterWithLectures(int id);
    Task<IEnumerable<ChapterTestWithQuestionsDto>> GetTestsForChapter(int chapterId);
    Task<ChapterDto> CreateChapter(ChapterForCreationDto chapter);
    Task UpdateChapter(int id, ChapterForUpdateDto chapter);
    Task DeleteChapter(int id);
}

