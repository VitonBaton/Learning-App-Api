using LearningApp.Contracts.Repositories;
using LearningApp.Entities;
using LearningApp.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Repositories;

public sealed class ChapterTestsRepository : RepositoryBase<ChapterTest>, IChapterTestsRepository
{
    public ChapterTestsRepository(DbSet<ChapterTest> entities)
        :base(entities)
    {
        
    }
    
    public async Task<IEnumerable<ChapterTest>> GetTestsForChapter(int chapterId)
    {
        var result = await FindByCondition(t => t.ChapterId.Equals(chapterId))
            .ToListAsync();
        return result;
    }
}
