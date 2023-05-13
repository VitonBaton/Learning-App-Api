using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

public sealed class ChapterTestResultsRepository : RepositoryBase<ChapterTestResult>, IChapterTestResultsRepository
{
    public ChapterTestResultsRepository(DbSet<ChapterTestResult> entities) : base(entities) { }

    public async Task<IEnumerable<ChapterTestResult>> GetResultsForTest(int testId)
    {
        var result = await FindByCondition(x => x.ChapterTestId == testId)
            .Include(x => x.User)
            .ToListAsync();
        return result;
    }
}
