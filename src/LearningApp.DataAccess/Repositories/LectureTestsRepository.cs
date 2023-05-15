using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

public sealed class LectureTestsRepository : RepositoryBase<LectureTest>, ILectureTestsRepository
{
    public LectureTestsRepository(DbSet<LectureTest> entities)
        : base(entities) { }

    public Task<LectureTest?> GetTestAsync(int testId)
    {
        return _entities
            .Include(x => x.LectureTestQuestions)
            .ThenInclude(x => x.LectureTestAnswers)
            .Include(x => x.LectureTestResults)
            .FirstOrDefaultAsync(x => x.Id == testId);
    }
}
