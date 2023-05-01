using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

public sealed class ChaptersRepository : RepositoryBase<Chapter>, IChaptersRepository
{
    public ChaptersRepository(DbSet<Chapter> entities)
        :base(entities)
    {

    }

    public async Task<IEnumerable<Chapter>> GetAllChaptersAsync()
    {
        var result = await FindAll()
            .OrderBy(ch => ch.Order)
            .ToListAsync();
        return result;
    }

    public Task<Chapter?> GetChapterWithTests(int id)
    {
        return FindByCondition(chapter => chapter.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public Task<Chapter?> GetChapterWithLectures(int id)
    {
        return FindByCondition(chapter => chapter.Id.Equals(id)).FirstOrDefaultAsync();
    }
}
