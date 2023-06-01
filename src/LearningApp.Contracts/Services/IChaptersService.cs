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

    Task<IEnumerable<ChapterWithTestsDto>> GetAllChaptersWithAllTests();

    Task<IEnumerable<TestResultDto>> GetTestResults(int testId);

    Task<TestDto> GetTestAsync(int testId);

    Task<TestDto> AddTestAsync(TestCreateDto test);

    Task DeleteTestAsync(int testId);

    Task<TestResultDto> CheckAnswersAsync(int testId, PassedTestDto test);
}
