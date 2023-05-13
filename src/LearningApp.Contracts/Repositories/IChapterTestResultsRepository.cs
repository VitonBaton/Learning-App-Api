using LearningApp.Models.Entities;

namespace LearningApp.Contracts.Repositories;

public interface IChapterTestResultsRepository : IRepositoryBase<ChapterTestResult>
{
    Task<IEnumerable<ChapterTestResult>> GetResultsForTest(int testId);
}
