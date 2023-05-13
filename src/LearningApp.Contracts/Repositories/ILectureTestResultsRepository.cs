using LearningApp.Models.Entities;

namespace LearningApp.Contracts.Repositories;

public interface ILectureTestResultsRepository : IRepositoryBase<LectureTestResult>
{
    Task<IEnumerable<LectureTestResult>> GetResultsForTest(int testId);
}
