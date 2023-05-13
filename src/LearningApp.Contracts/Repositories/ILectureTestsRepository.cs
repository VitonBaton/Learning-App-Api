using LearningApp.Models.Entities;

namespace LearningApp.Contracts.Repositories;

public interface ILectureTestsRepository : IRepositoryBase<LectureTest>
{
    Task<LectureTest?> GetTestAsync(int testId);
}
