using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

public sealed class ChapterTestsRepository : RepositoryBase<ChapterTest>, IChapterTestsRepository
{
    public ChapterTestsRepository(DbSet<ChapterTest> entities)
        : base(entities) { }

    public async Task<IEnumerable<ChapterTest>> GetTestsForChapter(int chapterId)
    {
        var result = await FindByCondition(t => t.ChapterId.Equals(chapterId))
            .ToListAsync();
        return result;
    }

    public Task<ChapterTest?> GetTestAsync(int testId)
    {
        return _entities
            .Include(x => x.ChapterTestQuestions)
            .ThenInclude(x => x.ChapterTestAnswers)
            .Include(x => x.ChapterTestResults)
            .FirstOrDefaultAsync(x => x.Id == testId);
    }
}
