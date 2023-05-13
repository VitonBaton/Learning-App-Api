using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

public class LectureTestResultsRepository : RepositoryBase<LectureTestResult>, ILectureTestResultsRepository
{
    public LectureTestResultsRepository(DbSet<LectureTestResult> entities) : base(entities) { }

    public async Task<IEnumerable<LectureTestResult>> GetResultsForTest(int testId)
    {
        var result = await FindByCondition(x => x.LectureTestId == testId)
            .Include(x => x.User)
            .ToListAsync();
        return result;
    }
}
